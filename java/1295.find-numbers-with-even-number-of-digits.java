/*
 * @lc app=leetcode id=1295 lang=java
 *
 * [1295] Find Numbers with Even Number of Digits
 */

// @lc code=start
class Solution {
    public int findNumbers(int[] nums) {
        int ret = 0;
        for (int num : nums) {
            if ((int)Math.log10(num) % 2 == 1) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

