/*
 * @lc app=leetcode id=1437 lang=java
 *
 * [1437] Check If All 1's Are at Least Length K Places Away
 */

// @lc code=start
class Solution {
    public boolean kLengthApart(int[] nums, int k) {
        int l = Integer.MIN_VALUE, n = nums.length;
        for (int i = 0; i < n; ++i) {
            if (nums[i] == 0) {
                continue;
            }
            if (i < l + k) {
                return false;
            }
            l = i;
        }
        return true;
    }
}
// @lc code=end

