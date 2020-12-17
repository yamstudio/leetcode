/*
 * @lc app=leetcode id=1578 lang=csharp
 *
 * [1578] Minimum Deletion Cost to Avoid Repeating Letters
 */

using System;

// @lc code=start
public class Solution {
    public int MinCost(string s, int[] cost) {
        int n = s.Length, ret = 0;
        for (int i = 0; i < n;) {
            int j = i, max = int.MinValue, total = 0;
            while (j < n && s[j] == s[i]) {
                max = Math.Max(max, cost[j]);
                total += cost[j++];
            }
            ret += total - max;
            i = j;
        }
        return ret;
    }
}
// @lc code=end

