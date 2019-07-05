/*
 * @lc app=leetcode id=37 lang=csharp
 *
 * [37] Sudoku Solver
 */
public class Solution {

    private bool SolveDFS(char[][] board, bool[,] rows, bool[,] cols, bool[,] boxes, int rstart, int cstart) {
        if (rstart >= 9) {
            return true;
        }
        if (board[rstart][cstart] != '.') {
            return SolveDFS(board, rows, cols, boxes, rstart + cstart / 8, (cstart + 1) % 9);
        }
        for (int c = 0; c < 9; ++c) {
            if (rows[rstart, c] || cols[cstart, c] || boxes[rstart - rstart % 3 + cstart / 3, c]) {
                continue;
            }
            board[rstart][cstart] = (char) (c + (int) '1');
            rows[rstart, c] = true;
            cols[cstart, c] = true;
            boxes[rstart - rstart % 3 + cstart / 3, c] = true;
            if (SolveDFS(board, rows, cols, boxes, rstart + cstart / 8, (cstart + 1) % 9)) {
                return true;
            }
            board[rstart][cstart] = '.';
            rows[rstart, c] = false;
            cols[cstart, c] = false;
            boxes[rstart - rstart % 3 + cstart / 3, c] = false;
        }
        return false;
    }

    public void SolveSudoku(char[][] board) {
        bool[,] rows = new bool[9, 9], cols = new bool[9, 9], boxes = new bool[9, 9];
        for (int i = 0; i < 9; ++i) {
            for (int j = 0; j < 9; ++j) {
                if (board[i][j] == '.') {
                    continue;
                }
                int c = (int) (board[i][j] - '1');
                rows[i, c] = true;
                cols[j, c] = true;
                boxes[i - i % 3 + j / 3, c] = true;
            }
        }
        SolveDFS(board, rows, cols, boxes, 0, 0);
    }
}

