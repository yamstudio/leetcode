/*
 * @lc app=leetcode id=782 lang=csharp
 *
 * [782] Transform to Chessboard
 */

using System;

// @lc code=start
public class Solution {
    public int MovesToChessboard(int[][] board) {
        int n = board.Length, rs = 0, cs = 0, rd = 0, cd = 0;
        for (int i = 0; i < n; ++i) {
            rs += board[0][i];
            cs += board[i][0];
            if (board[0][i] != i % 2) {
                ++rd;
            }
            if (board[i][0] != i % 2) {
                ++cd;
            }
            for (int j = 0; j < n; ++j) {
                if ((board[0][0] ^ board[i][0] ^ board[0][j] ^ board[i][j]) == 1) {
                    return -1;
                }
            }
        }
        if ((rs != n / 2 && rs != (n + 1) / 2) || (cs != n / 2 && cs != (n + 1) / 2)) {
            return -1;
        }
        if (n % 2 == 0) {
            rd = Math.Min(rd, n - rd);
            cd = Math.Min(cd, n - cd);
        } else {
            if (rd % 2 == 1) {
                rd = n - rd;
            }
            if (cd % 2 == 1) {
                cd = n - cd;
            }
        }
        return (cd + rd) / 2;
    }
}
// @lc code=end

