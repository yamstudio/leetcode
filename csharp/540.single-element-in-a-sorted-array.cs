/*
 * @lc app=leetcode id=540 lang=csharp
 *
 * [540] Single Element in a Sorted Array
 */

// @lc code=start
public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        int left = 0, right = nums.Length - 1;
        while (left < right) {
            int mid = left + (right - left) / 2, val = nums[mid];
            if (mid % 2 == 0) {
                if (val == nums[mid + 1]) {
                    left = mid + 2;
                } else {
                    right = mid;
                }
            } else {
                if (val == nums[mid - 1]) {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
        }
        return nums[left];
    }
}
// @lc code=end

