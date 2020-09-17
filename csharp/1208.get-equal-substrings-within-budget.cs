/*
 * @lc app=leetcode id=1208 lang=csharp
 *
 * [1208] Get Equal Substrings Within Budget
 */

using System;

// @lc code=start
public class Solution {
    public int EqualSubstring(string s, string t, int maxCost) {
        int l = 0, n = s.Length;
        for (int r = 0; r < n; ++r) {
            maxCost -= Math.Abs(s[r] - t[r]);
            if (maxCost < 0) {
                maxCost += Math.Abs(s[l] - t[l]);
                ++l;
            }
        }
        return n - l;
    }
}
// @lc code=end

