/*
 * @lc app=leetcode id=1041 lang=csharp
 *
 * [1041] Robot Bounded In Circle
 */

// @lc code=start
public class Solution {
    public bool IsRobotBounded(string instructions) {
        int x = 0, y = 0, dx = 0, dy = 1;
        foreach (var ins in instructions) {
            if (ins == 'G') {
                x += dx;
                y += dy;
            } else if (ins == 'L') {
                int t = dx;
                dx = -dy;
                dy = t;
            } else {
                int t = dx;
                dx = dy;
                dy = -t;
            }
        }
        return x == 0 && y == 0 || dx != 0 || dy != 1;
    }
}
// @lc code=end

