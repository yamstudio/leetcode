/*
 * @lc app=leetcode id=1037 lang=java
 *
 * [1037] Valid Boomerang
 */

// @lc code=start
class Solution {
    public boolean isBoomerang(int[][] points) {
        return (points[0][0] - points[2][0]) * (points[0][1] - points[1][1]) != (points[0][1] - points[2][1]) * (points[0][0] - points[1][0]);
    }
}
// @lc code=end

