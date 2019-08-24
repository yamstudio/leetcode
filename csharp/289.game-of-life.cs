/*
 * @lc app=leetcode id=289 lang=csharp
 *
 * [289] Game of Life
 */

using System.Linq;
using System;

public class Solution {

    private static (int, int)[] Dirs = new (int, int)[] {
        (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1),
    };

    public void GameOfLife(int[][] board) {
        int m = board.Length, n = board[0].Length;
        Func<(int, int), int> Sum = t => (t.Item1 >= 0 && t.Item1 < m && t.Item2 >= 0 && t.Item2 < n && (board[t.Item1][t.Item2] == 1 || board[t.Item1][t.Item2] == 2)) ? 1 : 0;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                int count = Dirs.Select(dir => (i + dir.Item1, j + dir.Item2)).Sum(Sum);
                if (board[i][j] > 0) {
                    if (count < 2 || count > 3) {
                        board[i][j] = 2;
                    }
                } else {
                    if (count == 3) {
                        board[i][j] = 3;
                    }
                }
            }
        }
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                board[i][j] %= 2;
            }
        }
    }
}

