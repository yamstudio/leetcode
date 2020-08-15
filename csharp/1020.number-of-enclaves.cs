/*
 * @lc app=leetcode id=1020 lang=csharp
 *
 * [1020] Number of Enclaves
 */

using System.Linq;

// @lc code=start
public class Solution {
    private static void Walk(int[][] A, int m, int n, int i, int j) {
        if (i < 0 || i >= m || j < 0 || j >= n || A[i][j] == 0) {
            return;
        }
        A[i][j] = 0;
        Walk(A, m, n, i, j - 1);
        Walk(A, m, n, i, j + 1);
        Walk(A, m, n, i - 1, j);
        Walk(A, m, n, i + 1, j);
    }
    
    public int NumEnclaves(int[][] A) {
        int m = A.Length, n = A[0].Length;
        for (int i = 0; i < m; ++i) {
            Walk(A, m, n, i, 0);
            Walk(A, m, n, i, n - 1);
        }
        for (int j = 0; j < n; ++j) {
            Walk(A, m, n, 0, j);
            Walk(A, m, n, m - 1, j);
        }
        return A
            .SelectMany(r => r)
            .Count(x => x == 1);
    }
}
// @lc code=end

