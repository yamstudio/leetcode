/*
 * @lc app=leetcode id=1574 lang=csharp
 *
 * [1574] Shortest Subarray to be Removed to Make Array Sorted
 */

using System;

// @lc code=start
public class Solution {
    public int FindLengthOfShortestSubarray(int[] arr) {
        int n = arr.Length, l = 0, r = n - 1;
        while (l < n - 1 && arr[l] <= arr[l + 1]) {
            ++l;
        }
        if (l == n - 1) {
            return 0;
        }
        while (r > l && arr[r] >= arr[r - 1]) {
            --r;
        }
        int ret = Math.Min(n - 1 - l, r), i = 0;
        while (i <= l && r < n) {
            if (arr[i] <= arr[r]) {
                ret = Math.Min(ret, r - i - 1);
                ++i;
            } else {
                ++r;
            }
        }
        return ret;
    }
}
// @lc code=end

