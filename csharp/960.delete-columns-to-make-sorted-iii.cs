/*
 * @lc app=leetcode id=960 lang=csharp
 *
 * [960] Delete Columns to Make Sorted III
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int MinDeletionSize(string[] A) {
        int n = A[0].Length;
        int[] dp = new int[n];
        for (int i = 0; i < n; ++i) {
            dp[i] = 1;
            for (int j = 0; j < i; ++j) {
                bool flag = false;
                foreach (string s in A) {
                    if (s[j] > s[i]) {
                        flag = true;
                        break;
                    }
                }
                if (!flag) {
                    dp[i] = Math.Max(dp[i], 1 + dp[j]);
                }
            }
        }
        return n - dp.Max();
    }
}
// @lc code=end

