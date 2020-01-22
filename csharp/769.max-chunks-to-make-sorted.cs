/*
 * @lc app=leetcode id=769 lang=csharp
 *
 * [769] Max Chunks To Make Sorted
 */

using System;

// @lc code=start
public class Solution {
    public int MaxChunksToSorted(int[] arr) {
        int n = arr.Length, ret = 0, max = -1;
        for (int i = 0; i < n; ++i) {
            max = Math.Max(max, arr[i]);
            if (i == max) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

