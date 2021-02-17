/*
 * @lc app=leetcode id=874 lang=java
 *
 * [874] Walking Robot Simulation
 */

// @lc code=start
class Solution {
    public int robotSim(int[] commands, int[][] obstacles) {
        Set<String> set = new HashSet<String>();
        for (int[] obstacle : obstacles) {
            set.add(String.format("%d,%d", obstacle[0], obstacle[1]));
        }
        int ret = 0, x = 0, y = 0, dx = 0, dy = 1;
        for (int c : commands) {
            if (c == -2) {
                int tdy = dy;
                dy = dx;
                dx = -tdy;
                continue;
            }
            if (c == -1) {
                int tdy = dy;
                dy = -dx;
                dx = tdy;
                continue;
            }
            for (int j = 0; j < c; ++j) {
                if (set.contains(String.format("%d,%d", x + dx, y + dy))) {
                    break;
                }
                x += dx;
                y += dy;
                ret = Math.max(ret, x * x + y * y);
            }
        }
        return ret;
    }
}
// @lc code=end

