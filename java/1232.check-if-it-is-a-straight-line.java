/*
 * @lc app=leetcode id=1232 lang=java
 *
 * [1232] Check If It Is a Straight Line
 */

// @lc code=start
class Solution {
    public boolean checkStraightLine(int[][] coordinates) {
        int n = coordinates.length;
        if (n == 2) {
            return true;
        }
        int x0 = coordinates[0][0], y0 = coordinates[0][1], dx = x0 - coordinates[1][0], dy = y0 - coordinates[1][1];
        for (int i = 2; i < n; ++i) {
            if (dy * (x0 - coordinates[i][0]) != dx * (y0 - coordinates[i][1])) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

