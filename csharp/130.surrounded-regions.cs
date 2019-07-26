/*
 * @lc app=leetcode id=130 lang=csharp
 *
 * [130] Surrounded Regions
 */
public class Solution {
    private void SolveDFS(char [][] board, int rows, int cols, int i, int j) {
        if (i < 0 || i >= rows || j < 0 || j >= cols || board[i][j] != 'O') {
            return;
        }
        board[i][j] = 'V';
        SolveDFS(board, rows, cols, i - 1, j);
        SolveDFS(board, rows, cols, i + 1, j);
        SolveDFS(board, rows, cols, i, j + 1);
        SolveDFS(board, rows, cols, i, j - 1);
    } 
    
    public void Solve(char[][] board) {
        int rows = board.Length, cols;
        if (rows == 0) {
            return;
        }
        cols = board[0].Length;
        for (int i = 0; i < rows; ++i) {
            for (int j = 0; j < cols; ++j) {
                if ((i == 0 || j == 0 || i == rows - 1 || j == cols - 1) && board[i][j] == 'O') {
                    SolveDFS(board, rows, cols, i, j);
                }
            }
        }
        for (int i = 0; i < rows; ++i) {
            for (int j = 0; j < cols; ++j) {
                if (board[i][j] == 'V') {
                    board[i][j] = 'O';
                } else if (board[i][j] == 'O') {
                    board[i][j] = 'X';
                }
            }
        }
    }
}

