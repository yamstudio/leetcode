/*
 * @lc app=leetcode id=581 lang=csharp
 *
 * [581] Shortest Unsorted Continuous Subarray
 */

// @lc code=start
public class Solution {
    public int FindUnsortedSubarray(int[] nums) {
        int n = nums.Length, start = -1, end = -2, max = nums[0], min = nums[n - 1];
        for (int i = 1; i < n; ++i) {
            int left = nums[i], right = nums[n - i - 1];
            if (max > left) {
                end = i;
            } else {
                max = left;
            }
            if (min < right) {
                start = n - i - 1;
            } else {
                min = right;
            }
        }
        return end - start + 1;
    }
}
// @lc code=end

