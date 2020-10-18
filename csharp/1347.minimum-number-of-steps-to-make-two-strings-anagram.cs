/*
 * @lc app=leetcode id=1347 lang=csharp
 *
 * [1347] Minimum Number of Steps to Make Two Strings Anagram
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int MinSteps(string s, string t) {
        int n = s.Length;
        int[] diff = new int[26];
        for (int i = 0; i < n; ++i) {
            ++diff[(int)s[i] - (int)'a'];
            --diff[(int)t[i] - (int)'a'];
        }
        return diff.Sum(Math.Abs) / 2;
    }
}
// @lc code=end

