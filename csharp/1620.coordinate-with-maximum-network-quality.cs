/*
 * @lc app=leetcode id=1620 lang=csharp
 *
 * [1620] Coordinate With Maximum Network Quality
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int[] BestCoordinate(int[][] towers, int radius) {
        int n = towers.Length, q = 0;
        int[] ret = new int[2];
        for (int i = 0; i < 51; ++i) {
            for (int j = 0; j < 51; ++j) {
                int acc = 0;
                for (int k = 0; k < n; ++k) {
                    double d = Math.Sqrt(Math.Pow((double)i - (double)towers[k][0], 2) + Math.Pow((double)j - (double)towers[k][1], 2));
                    if (d > (double)radius) {
                        continue;
                    }
                    acc += (int)(towers[k][2] / (1 + d));
                }
                if (acc > q) {
                    q = acc;
                    ret[0] = i;
                    ret[1] = j;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

