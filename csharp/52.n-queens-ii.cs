/*
 * @lc app=leetcode id=52 lang=csharp
 *
 * [52] N-Queens II
 */

using System.Collections.Generic;

public class Solution {

    private int count = 0;

    private bool isValid(int n, int row, int col, int[] pos) {
        for (int i = 0; i < row; ++i) {
            if (pos[i] == col || Math.Abs(row - i) == Math.Abs(pos[i] - col)) {
                return false;
            }
        }
        return true;
    }

    private void TotalNQueensDFS(int n, int curr, int[] pos) {
        if (curr == n) {
            ++count;
            return;
        }

        for (int i = 0; i < n; ++i) {
            if (!isValid(n, curr, i, pos)) {
                continue;
            }
            pos[curr] = i;
            TotalNQueensDFS(n, curr + 1, pos);
        }
    }

    public int TotalNQueens(int n) {
        TotalNQueensDFS(n, 0, new int[n]);
        return count;
    }
}

