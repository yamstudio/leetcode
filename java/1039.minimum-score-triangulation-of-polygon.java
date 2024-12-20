/*
 * @lc app=leetcode id=1039 lang=java
 *
 * [1039] Minimum Score Triangulation of Polygon
 */

// @lc code=start
class Solution {
    public int minScoreTriangulation(int[] values) {
        int n = values.length;
        return helper(values, 0, n - 1, new int[n][n]);
    }

    private static int helper(int[] values, int l, int r, int[][] memo) {
        if (l >= r - 1) {
            return 0;
        }
        if (memo[l][r] > 0) {
            return memo[l][r];
        }
        int base = values[l] * values[r], ret = Integer.MAX_VALUE;
        for (int i = l + 1; i < r; ++i) {
            ret = Math.min(ret, base * values[i] + helper(values, i, r, memo) + helper(values, l, i, memo));
        }
        memo[l][r] = ret;
        return ret;
    }
}
// @lc code=end

