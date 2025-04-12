/*
 * @lc app=leetcode id=1563 lang=java
 *
 * [1563] Stone Game V
 */

// @lc code=start
class Solution {
    public int stoneGameV(int[] stoneValue) {
        int n = stoneValue.length;
        int[] sums = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            sums[i + 1] = sums[i] + stoneValue[i];
        }
        return stoneGameV(sums, 0, n - 1, new int[n][n]);
    }

    private static int stoneGameV(int[] sums, int l, int r, int[][] memo) {
        if (l == r) {
            return 0;
        }
        int ret = memo[l][r];
        if (ret > 0) {
            return ret;
        }
        for (int m = l; m < r; ++m) {
            int lsum = sums[m + 1] - sums[l], rsum = sums[r + 1] - sums[m + 1];
            if (lsum > rsum) {
                ret = Math.max(ret, rsum + stoneGameV(sums, m + 1, r, memo));
            } else if (lsum < rsum) {
                ret = Math.max(ret, lsum + stoneGameV(sums, l, m, memo));
            } else {
                ret = Math.max(ret, Math.max(stoneGameV(sums, l, m, memo), stoneGameV(sums, m + 1, r, memo)) + lsum);
            }
        }
        memo[l][r] = ret;
        return ret;
    }
}
// @lc code=end

