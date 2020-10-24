/*
 * @lc app=leetcode id=1371 lang=csharp
 *
 * [1371] Find the Longest Substring Containing Vowels in Even Counts
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static IDictionary<char, int> Map = new Dictionary<char, int>() {
        { 'a', 0 },
        { 'e', 1 },
        { 'i', 2 },
        { 'o', 3 },
        { 'u', 4 }
    };

    public int FindTheLongestSubstring(string s) {
        int acc = 0, ret = 0, n = s.Length;
        var first = new Dictionary<int, int>();
        first[0] = -1;
        for (int i = 0; i < n; ++i) {
            if (Map.TryGetValue(s[i], out int j)) {
                acc ^= (1 << j);
            }
            if (first.TryGetValue(acc, out int p)) {
                ret = Math.Max(ret, i - p);
            } else {
                first[acc] = i;
            }
        }
        return ret;
    }
}
// @lc code=end

