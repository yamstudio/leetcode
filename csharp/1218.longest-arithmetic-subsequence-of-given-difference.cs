/*
 * @lc app=leetcode id=1218 lang=csharp
 *
 * [1218] Longest Arithmetic Subsequence of Given Difference
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int LongestSubsequence(int[] arr, int difference) {
        var map = new Dictionary<int, int>();
        int n = arr.Length, ret = 0;
        int[] count = new int[n];
        for (int i = 0; i < n; ++i) {
            int curr = arr[i];
            if (map.TryGetValue(curr - difference, out var j)) {
                count[i] = 1 + count[j];
            } else {
                count[i] = 1;
            }
            ret = Math.Max(ret, count[i]);
            map[curr] = i;
        }
        return ret;
    }
}
// @lc code=end

