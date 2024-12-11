/*
 * @lc app=leetcode id=1004 lang=java
 *
 * [1004] Max Consecutive Ones III
 */

// @lc code=start
class Solution {
    public int longestOnes(int[] nums, int k) {
        int n = nums.length, ret = 0, l = 0, z = 0;
        for (int r = 0; r < n; ++r) {
            if (nums[r] == 0) {
                ++z;
            }
            while (z > k) {
                if (nums[l++] == 0) {
                    --z;
                }
            }
            ret = Math.max(r - l + 1, ret);
        }
        return ret;
    }
}
// @lc code=end

