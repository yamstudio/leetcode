/*
 * @lc app=leetcode id=1380 lang=csharp
 *
 * [1380] Lucky Numbers in a Matrix
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<int> LuckyNumbers (int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        int[] cands = Enumerable.Repeat(-1, n).ToArray();
        var ret = new List<int>();
        for (int i = 0; i < m; ++i) {
            int mj = 0;
            for (int j = 1; j < n; ++j) {
                if (matrix[i][j] < matrix[i][mj]) {
                    mj = j;
                }
            }
            if (cands[mj] == -1 || matrix[cands[mj]][mj] < matrix[i][mj]) {
                cands[mj] = i;
            }
        }
        for (int j = 0; j < n; ++j) {
            int mi = cands[j];
            if (mi < 0) {
                continue;
            }
            bool flag = false;
            for (int i = 0; i < m && !flag; ++i) {
                if (matrix[i][j] > matrix[mi][j]) {
                    flag = true;
                }
            }
            if (!flag) {
                ret.Add(matrix[mi][j]);
            }
        }
        return ret;
    }
}
// @lc code=end

