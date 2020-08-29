/*
 * @lc app=leetcode id=1092 lang=csharp
 *
 * [1092] Shortest Common Supersequence 
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public string ShortestCommonSupersequence(string str1, string str2) {
        int l1 = str1.Length, l2 = str2.Length;
        var dp = new int[l1 + 1, l2 + 1];
        var ret = new Stack<char>();
        for (int i = 1; i <= l1; ++i) {
            for (int j = 1; j <= l2; ++j) {
                if (str1[i - 1] == str2[j - 1]) {
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                } else {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }
        while (l1 > 0 || l2 > 0) {
            if (l1 == 0) {
                ret.Push(str2[--l2]);
            } else if (l2 == 0) {
                ret.Push(str1[--l1]);
            } else if (str1[l1 - 1] == str2[l2 - 1]) {
                ret.Push(str1[--l1]);
                --l2;
            } else if (dp[l1, l2] == dp[l1 - 1, l2]) {
                ret.Push(str1[--l1]);
            } else {
                ret.Push(str2[--l2]);
            }
        }
        return new string(ret.ToArray());
    }
}
// @lc code=end

