/*
 * @lc app=leetcode id=529 lang=csharp
 *
 * [529] Minesweeper
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static void LoopNeighbors(char[][] board, int m, int n, int r, int c, Action<int, int> action) {
        for (int i = -1; i < 2; ++i) {
            for (int j = -1; j < 2; ++j) {
                int nr = r + i, nc = c + j;
                if ((nr == r && nc == c) || nr < 0 || nr >= m || nc < 0 || nc >= n) {
                    continue;
                }
                action(nr, nc);
            }
        }
    }

    public char[][] UpdateBoard(char[][] board, int[] click) {
        int m = board.Length, n = board[0].Length, r = click[0], c = click[1];
        if (board[r][c] == 'M') {
            board[r][c] = 'X';
            return board;
        }
        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((r, c));
        while (queue.Count != 0) {
            var pair = queue.Dequeue();
            r = pair.Item1;
            c = pair.Item2;
            int count = 0;
            if (board[r][c] != 'E') {
                continue;
            }
            LoopNeighbors(board, m, n, r, c, (nr, nc) => {
                if (board[nr][nc] == 'M') {
                    ++count;
                }
            });
            if (count > 0) {
                board[r][c] = (char) (count + (int) '0');
                continue;
            }
            board[r][c] = 'B';
            LoopNeighbors(board, m, n, r, c, (nr, nc) => {
                if (board[nr][nc] == 'E') {
                    queue.Enqueue((nr, nc));
                }
            });
        }
        return board;
    }
}
// @lc code=end

