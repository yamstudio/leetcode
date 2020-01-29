/*
 * @lc app=leetcode id=794 lang=csharp
 *
 * [794] Valid Tic-Tac-Toe State
 */

using System.Linq;

// @lc code=start
public class Solution {

    private static bool IsWin(string[] board, char c) {
        return board.Any(row => row.All(x => x == c))
            || Enumerable.Range(0, 3).Any(j => Enumerable.Range(0, 3).All(i => board[i][j] == c))
            || Enumerable.Range(0, 3).All(i => board[i][i] == c)
            || Enumerable.Range(0, 3).All(i => board[i][2 - i] == c);
    }

    public bool ValidTicTacToe(string[] board) {
        int x = 0, o = 0;
        foreach (var row in board) {
            foreach (var c in row) {
                if (c == 'X') {
                    ++x;
                } else if (c == 'O') {
                    ++o;
                }
            }
        }
        return (x == o && !IsWin(board, 'X')) || (x == o + 1 && !IsWin(board, 'O'));
    }
}
// @lc code=end

