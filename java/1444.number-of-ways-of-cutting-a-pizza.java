/*
 * @lc app=leetcode id=1444 lang=java
 *
 * [1444] Number of Ways of Cutting a Pizza
 */

// @lc code=start
class Solution {
    public int ways(String[] pizza, int k) {
        int m = pizza.length, n = pizza[0].length();
        int[][] apples = new int[m + 1][n + 1];
        for (int i = m - 1; i >= 0; --i) {
            for (int j = n - 1; j >= 0; --j) {
                apples[i][j] = apples[i + 1][j] + apples[i][j + 1] - apples[i + 1][j + 1] + (pizza[i].charAt(j) == 'A' ? 1 : 0);
            }
        }
        return ways(apples, 0, 0, k - 1, new Integer[k][m][n]);
    }

    private static int ways(int[][] apples, int r, int c, int cuts, Integer[][][] memo) {
        if (apples[r][c] == 0) {
            return 0;
        }
        if (cuts == 0) {
            return 1;
        }
        Integer existing = memo[cuts][r][c];
        if (existing != null) {
            return existing;
        }
        int ret = 0, m = apples.length - 1, n = apples[0].length - 1;
        for (int nr = r + 1; nr < m; ++nr) {
            if (apples[nr][c] < apples[r][c]) {
                ret = (ret + ways(apples, nr, c, cuts - 1, memo)) % 1000000007;
            }
        }
        for (int nc = c + 1; nc < n; ++nc) {
            if (apples[r][nc] < apples[r][c]) {
                ret = (ret + ways(apples, r, nc, cuts - 1, memo)) % 1000000007;
            }
        }
        memo[cuts][r][c] = ret;
        return ret;
    }
}
// @lc code=end

