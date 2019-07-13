/*
 * @lc app=leetcode id=79 lang=csharp
 *
 * [79] Word Search
 */
public class Solution {
    private bool ExistDFS(char[][] board, string word, bool[,] used, int rows, int cols, int r, int c, int i) {
        if (i == word.Length) {
            return true;
        }
        if (r < 0 || r >= rows || c < 0 || c >= cols || board[r][c] != word[i] || used[r, c]) {
            return false;
        }
        used[r, c] = true;
        if (ExistDFS(board, word, used, rows, cols, r - 1, c, i + 1)
            || ExistDFS(board, word, used, rows, cols, r + 1, c, i + 1)
            || ExistDFS(board, word, used, rows, cols, r, c - 1, i + 1)
            || ExistDFS(board, word, used, rows, cols, r, c + 1, i + 1)) {
            return true;
        }
        used[r, c] = false;
        return false;
    }

    public bool Exist(char[][] board, string word) {
        int rows = board.Length, cols = board[0].Length;
        bool[,] used = new bool[rows, cols];
        for (int r = 0; r < rows; ++r) {
            for (int c = 0; c < cols; ++c) {
                if (ExistDFS(board, word, used, rows, cols, r, c, 0)) {
                    return true;
                }
            }
        }
        return false;
    }
}

