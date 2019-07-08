/*
 * @lc app=leetcode id=51 lang=csharp
 *
 * [51] N-Queens
 */

using System.Collections.Generic;

public class Solution {

    private bool isValid(int n, int row, int col, int[] pos) {
        for (int i = 0; i < row; ++i) {
            if (pos[i] == col || Math.Abs(row - i) == Math.Abs(pos[i] - col)) {
                return false;
            }
        }
        return true;
    }

    private void SolveNQueensDFS(int n, int curr, IList<IList<string>> ret, int[] pos) {
        if (curr == n) {
            char[] row = new char[n];
            IList<string> board = new List<string>(n);
            for (int i = 0; i < n; ++i) {
                row[i] = '.';
            }
            for (int i = 0; i < n; ++i) {
                row[pos[i]] = 'Q';
                board.Add(new string(row));
                row[pos[i]] = '.';
            }
            ret.Add(board);
        }

        for (int i = 0; i < n; ++i) {
            if (!isValid(n, curr, i, pos)) {
                continue;
            }
            pos[curr] = i;
            SolveNQueensDFS(n, curr + 1, ret, pos);
        }
    }

    public IList<IList<string>> SolveNQueens(int n) {
        IList<IList<string>> ret = new List<IList<string>>();
        SolveNQueensDFS(n, 0, ret, new int[n]);
        return ret;
    }
}

