/*
 * @lc app=leetcode id=1300 lang=csharp
 *
 * [1300] Sum of Mutated Array Closest to Target
 */

using System;

// @lc code=start
public class Solution {
    public int FindBestValue(int[] arr, int target) {
        int n = arr.Length, i = 0, ret;
        Array.Sort(arr);
        while (i < n && target > (n - i) * arr[i]) {
            target -= arr[i++];
        }
        if (i == n) {
            return arr[n - 1];
        }
        ret = target / (n - i);
        if ((ret + 1) * (n - i) - target < target - ret * (n - i)) {
            ++ret;
        }
        return ret;
    }
}
// @lc code=end

