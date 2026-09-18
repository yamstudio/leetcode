/*
 * @lc app=leetcode id=1822 lang=java
 *
 * [1822] Sign of the Product of an Array
 */

// @lc code=start
class Solution {
    public int arraySign(int[] nums) {
        return arraySign(nums, 0, 1);
    }

    private static int arraySign(int[] nums, int i, int acc) {
        if (i == nums.length) {
            return acc;
        }
        int v = nums[i];
        if (v == 0) {
            return 0;
        }
        return arraySign(nums, i + 1, v > 0 ? acc : -acc);
    }
}
// @lc code=end

