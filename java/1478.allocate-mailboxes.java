/*
 * @lc app=leetcode id=1478 lang=java
 *
 * [1478] Allocate Mailboxes
 */

import java.util.Arrays;

// @lc code=start

class Solution {

    private static final int IMPOSSIBLE = 1234567;

    public int minDistance(int[] houses, int k) {
        Arrays.sort(houses);
        int n = houses.length;
        int[][] cost = new int[n][n];
        for (int i = 0; i < n; ++i) {
            for (int j = i + 1; j < n; ++j) {
                int m = houses[(i + j) / 2];
                for (int l = i; l <= j; ++l) {
                    cost[i][j] += Math.abs(m - houses[l]);
                }
            }
        }
        return minDistance(cost, k, n, 0, new Integer[k + 1][n]);
    }

    private static int minDistance(int[][] cost, int k, int n, int i, Integer[][] memo) {
        if (k < 0) {
            return IMPOSSIBLE;
        }
        if (n == i) {
            return k == 0 ? 0 : IMPOSSIBLE;
        }
        Integer m = memo[k][i];
        if (m != null) {
            return m;
        }
        int ret = IMPOSSIBLE;
        for (int ni = i; ni < n; ++ni) {
            ret = Math.min(ret, cost[i][ni] + minDistance(cost, k - 1, n, ni + 1, memo));
        }
        memo[k][i] = ret;
        return ret;
    }
}
// @lc code=end

