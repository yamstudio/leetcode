/*
 * @lc app=leetcode id=920 lang=csharp
 *
 * [920] Number of Music Playlists
 */

// @lc code=start
public class Solution {
    public int NumMusicPlaylists(int N, int L, int K) {
        int w = 1;
        int[,] dp = new int[2, N + 1];
        dp[0, 0] = 1;
        for (int i = 1; i <= L; ++i) {
            dp[w, 0] = 0;
            for (int j = 1; j <= N; ++j) {
                long val = ((long)dp[1 - w, j - 1] * (long)(N - j + 1)) % 1000000007;
                if (j > K) {
                    val = (val + ((long)dp[1 - w, j] * (long)(j - K)) % 1000000007) % 1000000007;
                }
                dp[w, j] = (int)val;
            }
            w = 1 - w;
        }
        return dp[1 - w, N];
    }
}
// @lc code=end

