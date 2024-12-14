/*
 * @lc app=leetcode id=1017 lang=java
 *
 * [1017] Convert to Base -2
 */

// @lc code=start
class Solution {
    public String baseNeg2(int n) {
        if (n == 0) {
            return "0";
        }
        StringBuilder sb = new StringBuilder();
        while (n != 0) {
            sb.insert(0, n & 1);
            n = -(n >> 1);
        }
        return sb.toString();
    }
}
// @lc code=end

