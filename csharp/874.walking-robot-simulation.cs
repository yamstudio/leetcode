/*
 * @lc app=leetcode id=874 lang=csharp
 *
 * [874] Walking Robot Simulation
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int RobotSim(int[] commands, int[][] obstacles) {
        var set = new HashSet<(int X, int Y)>(obstacles.Select(obstacle => (X: obstacle[0], Y: obstacle[1])));
        int ret = 0, x = 0, y = 0, dx = 0, dy = 1;
        foreach (var command in commands) {
            if (command == -2) {
                if (dx == 0) {
                    dx = -dy;
                    dy = 0;
                } else {
                    dy = dx;
                    dx = 0;
                }
                continue;
            }
            if (command == -1) {
                if (dx == 0) {
                    dx = dy;
                    dy = 0;
                } else {
                    dy = -dx;
                    dx = 0;
                }
                continue;
            }
            int c = command;
            while (c-- > 0) {
                if (set.Contains((X: x + dx, Y: y + dy))) {
                    break;
                }
                x += dx;
                y += dy;
                ret = Math.Max(ret, x * x + y * y);
            }
        }
        return ret;
    }
}
// @lc code=end

