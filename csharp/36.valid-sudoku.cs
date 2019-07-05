/*
 * @lc app=leetcode id=36 lang=csharp
 *
 * [36] Valid Sudoku
 */
public class Solution {
    public bool IsValidSudoku(char[][] board) {
        bool[,] rows = new bool[9, 9], cols = new bool[9, 9], boxes = new bool[9, 9];
        for (int i = 0; i < 9; ++i) {
            for (int j = 0; j < 9; ++j) {
                int c = (int) (board[i][j] - '1');
                if (c < 0 || c > 8) {
                    continue;
                }
                if (rows[i, c] || cols[j, c] || boxes[i - i % 3 + j / 3, c]) {
                    return false;
                }
                rows[i, c] = true;
                cols[j, c] = true;
                boxes[i - i % 3 + j / 3, c] = true;
            }
        }
        return true;
    }
}

