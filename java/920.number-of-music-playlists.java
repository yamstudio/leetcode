/*
 * @lc app=leetcode id=920 lang=java
 *
 * [920] Number of Music Playlists
 */

// @lc code=start
class Solution {
    public int numMusicPlaylists(int N, int L, int K) {
        long[][] dp = new long[L + 1][N + 1];
        dp[0][0] = 1;
        for (int i = 1; i <= L; ++i) {
            for (int j = 1; j <= N; ++j) {
                dp[i][j] = (dp[i - 1][j - 1] * (N - (j - 1))) % 1000000007;
                if (j > K) {
                    dp[i][j] = (dp[i][j] + dp[i - 1][j] * (j - K)) % 1000000007;
                }
            }
        }
        return (int)dp[L][N];
    }
}
// @lc code=end

