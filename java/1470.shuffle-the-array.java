/*
 * @lc app=leetcode id=1470 lang=java
 *
 * [1470] Shuffle the Array
 */

// @lc code=start
class Solution {
    public int[] shuffle(int[] nums, int n) {
        for (int i = 0; i < n; ++i) {
            nums[i + n] = (nums[i + n] << 10) | nums[i];
        }
        for (int i = 0; i < n; ++i) {
            nums[i * 2 ] = nums[i + n] & 1023;
            nums[i * 2 + 1] = nums[i + n] >> 10;
        }
        return nums;
    }
}
// @lc code=end

