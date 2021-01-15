/*
 * @lc app=leetcode id=780 lang=java
 *
 * [780] Reaching Points
 */

// @lc code=start
class Solution {
    public boolean reachingPoints(int sx, int sy, int tx, int ty) {
        if (sx > tx || sy > ty) {
            return false;
        }
        while (tx > sx && ty > sy) {
            if (tx > ty) {
                tx %= ty;
            } else {
                ty %= tx;
            }
        }
        if (tx == sx) {
            return (ty - sy) % sx == 0;
        }
        if (ty == sy) {
            return (tx - sx) % sy == 0;
        }
        return false;
    }
}
// @lc code=end

