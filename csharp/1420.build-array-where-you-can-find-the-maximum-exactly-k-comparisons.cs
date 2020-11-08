/*
 * @lc app=leetcode id=1420 lang=csharp
 *
 * [1420] Build Array Where You Can Find The Maximum Exactly K Comparisons
 */

// @lc code=start
public class Solution {
    public int NumOfArrays(int n, int m, int k) {
        long[,,] dp = new long[n + 1, m + 1, k + 1];
        for (int j = 1; j <= m; ++j) {
            dp[1, j, 1] = 1;
        }
        for (int i = 1; i <= n; ++i) {
            for (int j = 1; j <= m; ++j) {
                for (int c = 1; c <= k; ++c) {
                    long t = (dp[i, j, c] + j * dp[i - 1, j, c]) % 1000000007;
                    for (int pj = 1; pj < j; ++pj) {
                        t = (t + dp[i - 1, pj, c - 1]) % 1000000007;
                    }
                    dp[i, j, c] = t;
                }
            }
        }
        long ret = 0;
        for (int j = 1; j <= m; ++j) {
            ret = (ret + dp[n, j, k]) % 1000000007;
        }
        return (int)ret;
    }
}
// @lc code=end

