/*
 * @lc app=leetcode id=782 lang=java
 *
 * [782] Transform to Chessboard
 */

// @lc code=start
class Solution {
    public int movesToChessboard(int[][] board) {
        int n = board.length, rCount = 0, cCount = 0, rDiff = 0, cDiff = 0;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if ((board[0][0] ^ board[i][0] ^ board[i][j] ^ board[0][j]) == 1) {
                    return -1;
                }
            }
            rCount += board[0][i];
            cCount += board[i][1];
            rDiff += board[0][i] ^ (i % 2);
            cDiff += board[i][0] ^ (i % 2);
        }
        if (rCount != n / 2 && rCount != (n + 1) / 2 || cCount != n / 2 && cCount != (n + 1) / 2) {
            return -1;
        }
        if (n % 2 == 0) {
            return Math.min(rDiff, n - rDiff) / 2 + Math.min(cDiff, n - cDiff) / 2;
        }
        if (rDiff % 2 == 1) {
            rDiff = n - rDiff;
        }
        if (cDiff % 2 == 1) {
            cDiff = n - cDiff;
        }
        return rDiff / 2 + cDiff / 2;
    }
}
// @lc code=end

