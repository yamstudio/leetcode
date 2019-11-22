/*
 * @lc app=leetcode id=688 lang=csharp
 *
 * [688] Knight Probability in Chessboard
 */

// @lc code=start
public class Solution {

    private static readonly int[][] Dirs = new int[][] {
        new int[] { -1, -2, },
        new int[] { 1, -2, },
        new int[] { -1, 2, },
        new int[] { 1, 2, },
        new int[] { -2, -1, },
        new int[] { 2, -1, },
        new int[] { -2, 1, },
        new int[] { 2, 1, },
    };

    private static double KnightProbabilityRecurse(double[,,] p, int n, int k, int r, int c) {
        if (k == 0) {
            return 1.0;
        }
        if (p[k, r, c] != 0.0) {
            return p[k, r, c];
        }
        foreach (var dir in Dirs) {
            int nr = r + dir[0], nc = c + dir[1];
            if (nr < 0 || nr >= n || nc < 0 || nc >= n) {
                continue;
            }
            p[k, r, c] += KnightProbabilityRecurse(p, n, k - 1, nr, nc);
        }
        return p[k, r, c];
    }

    public double KnightProbability(int N, int K, int r, int c) {
        return KnightProbabilityRecurse(new double[K + 1, N, N], N, K, r, c) / Math.Pow(8, K);
    }
}
// @lc code=end

