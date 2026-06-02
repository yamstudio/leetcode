/*
 * @lc app=leetcode id=1752 lang=java
 *
 * [1752] Check if Array Is Sorted and Rotated
 */

// @lc code=start
class Solution {
    public boolean check(int[] nums) {
        int n = nums.length, mi = 0;
        for (int i = 1; i < n; ++i) {
            int v = nums[i];
            if (v > nums[mi]) {
                continue;
            }
            if (v < nums[mi] || nums[i] != nums[i - 1]) {
                mi = i;
            }
        }
        for (int i = 1; i < n; ++i) {
            if (nums[(mi + i + n) % n] < nums[(mi + i - 1 + n) % n]) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

