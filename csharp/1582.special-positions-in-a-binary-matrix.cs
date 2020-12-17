/*
 * @lc app=leetcode id=1582 lang=csharp
 *
 * [1582] Special Positions in a Binary Matrix
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int NumSpecial(int[][] mat) {
        int m = mat.Length, n = mat[0].Length, ret = 0;
        var rs = Enumerable.Repeat(-1, m).ToArray();
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (mat[i][j] == 0) {
                    continue;
                }
                if (rs[i] < 0) {
                    rs[i] = j;
                } else {
                    rs[i] = -1;
                    break;
                }
            }
        }
        for (int j = 0; j < n; ++j) {
            int r = -1;
            for (int i = 0; i < m; ++i) {
                if (mat[i][j] == 0) {
                    continue;
                }
                if (r == -1) {
                    r = i;
                } else {
                    r = -1;
                    break;
                }
            }
            if (r >= 0 && rs[r] == j) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

