/*
 * @lc app=leetcode id=1252 lang=java
 *
 * [1252] Cells with Odd Values in a Matrix
 */

// @lc code=start
class Solution {
    public int oddCells(int m, int n, int[][] indices) {
        long rows = 0, cols = 0;
        for (var i : indices) {
            rows ^= (1L << i[0]);
            cols ^= (1L << i[1]);
        }
        int oddRows = 0, oddCols = 0;
        while (rows != 0) {
            oddRows += (rows & 1);
            rows >>= 1;
        }
        while (cols != 0) {
            oddCols += (cols & 1);
            cols >>= 1;
        }
        return oddRows * (n - oddCols) + oddCols * (m - oddRows);
    }
}
// @lc code=end

