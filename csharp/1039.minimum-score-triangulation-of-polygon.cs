/*
 * @lc app=leetcode id=1039 lang=csharp
 *
 * [1039] Minimum Score Triangulation of Polygon
 */

using System;

// @lc code=start
public class Solution {

    private static int MinScoreTriangulationRecurse(int[] A, int[,] dp, int l, int r) {
        if (l >= r - 1) {
            return 0;
        }
        if (dp[l, r] > 0) {
            return dp[l, r];
        }
        int ret = int.MaxValue, b = A[l] * A[r];
        for (int m = l + 1; m < r; ++m) {
            ret = Math.Min(ret, b * A[m] + MinScoreTriangulationRecurse(A, dp, l, m) + MinScoreTriangulationRecurse(A, dp, m, r));
        }
        dp[l, r] = ret;
        return ret;
    }

    public int MinScoreTriangulation(int[] A) {
        int n = A.Length;
        return MinScoreTriangulationRecurse(A, new int[n, n], 0, n - 1);
    }
}
// @lc code=end

