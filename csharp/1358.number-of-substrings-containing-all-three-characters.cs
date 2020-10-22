/*
 * @lc app=leetcode id=1358 lang=csharp
 *
 * [1358] Number of Substrings Containing All Three Characters
 */

using System;

// @lc code=start
public class Solution {
    public int NumberOfSubstrings(string s) {
        int[] indices = new int[] { -1, -1, -1 };
        int n = s.Length, ret = 0;
        for (int i = 0; i < n; ++i) {
            int j = (int)s[i] - (int)'a';
            indices[j] = i;
            ret += Math.Min(indices[(j + 1) % 3], indices[(j + 2) % 3]) + 1;
        }
        return ret;
    }
}
// @lc code=end

