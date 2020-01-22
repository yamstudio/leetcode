/*
 * @lc app=leetcode id=768 lang=csharp
 *
 * [768] Max Chunks To Make Sorted II
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int MaxChunksToSorted(int[] arr) {
        int n = arr.Length, ret = 1, max = -1;
        int[] mins = new int[n];
        mins[n - 1] = arr[n - 1];
        for (int i = n - 2; i >= 0; --i) {
            mins[i] = Math.Min(arr[i], mins[i + 1]);
        }
        for (int i = 0; i < n - 1; ++i) {
            max = Math.Max(max, arr[i]);
            if (max <= mins[i + 1]) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

