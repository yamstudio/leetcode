/*
 * @lc app=leetcode id=419 lang=csharp
 *
 * [419] Battleships in a Board
 */
public class Solution {
    public int CountBattleships(char[][] board) {
        int m = board.Length, n, ret = 0;
        if (m == 0) {
            return 0;
        }
        n = board[0].Length;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (board[i][j] == 'X' && (i == 0 || board[i - 1][j] != 'X') && (j == 0 || board[i][j - 1] != 'X')) {
                    ret++;
                }
            }
        }
        return ret;
    }
}

