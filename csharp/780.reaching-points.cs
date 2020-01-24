/*
 * @lc app=leetcode id=780 lang=csharp
 *
 * [780] Reaching Points
 */

// @lc code=start
public class Solution {
    public bool ReachingPoints(int sx, int sy, int tx, int ty) {
        if (sx > tx || sy > ty) {
            return false;
        }
        while (tx >= sx && ty >= sy) {
            if (tx >= ty) {
                tx %= ty;
            } else {
                ty %= tx;
            }
        }
        if (tx == sx) {
            return (ty - sy + sx) % sx == 0;
        }
        if (ty == sy) {
            return (tx - sx + sy) % sy == 0;
        }
        return false;
    }
}
// @lc code=end

