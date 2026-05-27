/*
 * @lc app=leetcode id=1748 lang=java
 *
 * [1748] Sum of Unique Elements
 */

// @lc code=start
class Solution {
    public int sumOfUnique(int[] nums) {
        int[] count = new int[101];
        for (int x : nums) {
            ++count[x];
        }
        int ret = 0;
        for (int i = 1; i <= 100; ++i) {
            if (count[i] == 1) {
                ret += i;
            }
        }
        return ret;
    }
}
// @lc code=end

