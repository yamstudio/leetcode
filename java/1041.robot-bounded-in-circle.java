/*
 * @lc app=leetcode id=1041 lang=java
 *
 * [1041] Robot Bounded In Circle
 */

// @lc code=start
class Solution {
    public boolean isRobotBounded(String instructions) {
        int x = 0, y = 0, dx = 0, dy = 1, n = instructions.length();
        for (int i = 0; i < n; ++i) {
            char c = instructions.charAt(i);
            if (c == 'G') {
                x += dx;
                y += dy;
            } else if (c == 'L') {
                int ndy = dx;
                dx = -dy;
                dy = ndy;
            } else {
                int ndy = -dx;
                dx = dy;
                dy = ndy;
            }
        }
        return x == 0 && y == 0 || dx != 0 || dy != 1;
    }
}
// @lc code=end

