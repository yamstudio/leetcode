/*
 * @lc app=leetcode id=719 lang=csharp
 *
 * [719] Find K-th Smallest Pair Distance
 */

using System;

// @lc code=start
public class Solution {
    public int SmallestDistancePair(int[] nums, int k) {
        int n = nums.Length, left = 0, right;
        Array.Sort(nums);
        right = nums[n - 1] - nums[0];
        while (left < right) {
            int mid = (left + right) / 2, curr = 0, i = 0;
            for (int j = 0; j < n; ++j) {
                while (i < n && nums[j] - nums[i] > mid) {
                    ++i;
                }
                curr += j - i;
            }
            if (curr < k) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        return right;
    }
}
// @lc code=end

