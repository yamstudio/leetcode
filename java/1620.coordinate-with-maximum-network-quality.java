/*
 * @lc app=leetcode id=1620 lang=java
 *
 * [1620] Coordinate With Maximum Network Quality
 */

// @lc code=start
class Solution {
    public int[] bestCoordinate(int[][] towers, int radius) {
        int n = towers.length, retX = -1, retY = -1;
        long max = -1;
        for (int x = 0; x <= 50; ++x) {
            for (int y = 0; y <= 50; ++y) {
                long sig = 0;
                for (int i = 0; i < n; ++i) {
                    double d = Math.sqrt(Math.pow((double)x - (double)towers[i][0], 2) + Math.pow((double)y - (double)towers[i][1], 2));
                    if (d > radius) {
                        continue;
                    }
                    sig += (long)Math.floor((double)towers[i][2] / (1.0 + d));
                }
                if (sig > max) {
                    max = sig;
                    retX = x;
                    retY = y;
                }
            }
        }
        return new int[] { retX, retY };
    }
}
// @lc code=end

