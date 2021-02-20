/*
 * @lc app=leetcode id=885 lang=java
 *
 * [885] Spiral Matrix III
 */

// @lc code=start
class Solution {
    public int[][] spiralMatrixIII(int R, int C, int r0, int c0) {
        int n = R * C, dir = 1, i = 0;
        int[][] ret = new int[n][2];
        for (int d = 1; i < n; ++d) {
            if (r0 >= 0 && r0 < R) {
                for (int s = 0; s < d; ++s) {
                    if (c0 >= 0 && c0 < C) {
                        ret[i][0] = r0;
                        ret[i++][1] = c0;
                    }
                    c0 += dir;
                }
            } else {
                c0 += d * dir;
            }
            if (c0 >= 0 && c0 < C) {
                for (int s = 0; s < d; ++s) {
                    if (r0 >= 0 && r0 < R) {
                        ret[i][0] = r0;
                        ret[i++][1] = c0;
                    }
                    r0 += dir;
                }
            } else {
                r0 += d * dir;
            }
            dir = -dir;
        }
        return ret;
    }
}
// @lc code=end

