/*
 * @lc app=leetcode id=1252 lang=csharp
 *
 * [1252] Cells with Odd Values in a Matrix
 */

// @lc code=start
public class Solution {
    public int OddCells(int n, int m, int[][] indices) {
        long r = 0, c = 0;
        int rc = 0, cc = 0;
        foreach (var i in indices) {
            r ^= 1L << i[0];
            c ^= 1L << i[1];
        }
        while (r != 0) {
            rc += (int)(r & 1);
            r >>= 1;
        }
        while (c != 0) {
            cc += (int)(c & 1);
            c >>= 1;
        }
        return rc * m + cc * n - 2 * rc * cc;
    }
}
// @lc code=end

