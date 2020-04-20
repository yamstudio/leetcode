/*
 * @lc app=leetcode id=885 lang=csharp
 *
 * [885] Spiral Matrix III
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int[][] SpiralMatrixIII(int R, int C, int r0, int c0) {
        int n = R * C, delta = 1, i = 0;
        int[][] ret = new int[n][];
        for (int d = 1; i < n; ++d) {
            if (r0 >= 0 && r0 < R) {
                for (int s = 0; s < d; ++s) {
                    if (c0 >= 0 && c0 < C) {
                        ret[i++] = new int[] { r0, c0 };
                    }
                    c0 += delta;
                }
            } else {
                c0 += d * delta;
            }
            if (c0 >= 0 && c0 < C) {
                for (int s = 0; s < d; ++s) {
                    if (r0 >= 0 && r0 < R) {
                        ret[i++] = new int[] { r0, c0 };
                    }
                    r0 += delta;
                }
            } else {
                r0 += d * delta;
            }
            delta = -delta;
        }
        return ret;
    }
}
// @lc code=end

