/*
 * @lc app=leetcode id=1464 lang=java
 *
 * [1464] Maximum Product of Two Elements in an Array
 */

// @lc code=start
class Solution {
    public int maxProduct(int[] nums) {
        int m = -1, m2 = -1;
        for (int num : nums) {
            if (num > m) {
                m2 = m;
                m = num;
            } else if (num > m2) {
                m2 = num;
            }
        }
        return (m2 - 1) * (m - 1);
    }
}
// @lc code=end

