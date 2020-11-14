/*
 * @lc app=leetcode id=1444 lang=csharp
 *
 * [1444] Number of Ways of Cutting a Pizza
 */

// @lc code=start
public class Solution {

    private int Ways(int[,] apples, int m, int n, int cuts, int r, int c, int?[,,] memo) {
        if (apples[r, c] == 0) {
            return 0;
        }
        if (cuts == 0) {
            return 1;
        }
        if (memo[cuts, r, c].HasValue) {
            return memo[cuts, r, c].Value;
        }
        int ret = 0;
        for (int nr = r + 1; nr < m; ++nr) {
            if (apples[nr, c] < apples[r, c]) {
                ret = (ret + Ways(apples, m, n, cuts - 1, nr, c, memo)) % 1000000007;
            }
        }
        for (int nc = c + 1; nc < n; ++nc) {
            if (apples[r, nc] < apples[r, c]) {
                ret = (ret + Ways(apples, m, n, cuts - 1, r, nc, memo)) % 1000000007;
            }
        }
        memo[cuts, r, c] = ret;
        return ret;
    }

    public int Ways(string[] pizza, int k) {
        int m = pizza.Length, n = pizza[0].Length;
        int[,] apples = new int[m + 1, n + 1];
        for (int r = m - 1; r >= 0; --r) {
            for (int c = n - 1; c >= 0; --c) {
                apples[r, c] = apples[r + 1, c] + apples[r, c + 1] - apples[r + 1, c + 1] + (pizza[r][c] == 'A' ? 1 : 0);
            }
        }
        return Ways(apples, m, n, k - 1, 0, 0, new int?[k, m, n]);
    }
}
// @lc code=end

