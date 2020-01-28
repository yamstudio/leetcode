/*
 * @lc app=leetcode id=790 lang=csharp
 *
 * [790] Domino and Tromino Tiling
 */

// @lc code=start
public class Solution {
    public int NumTilings(int N) {
        long[] dp = new long[N + 2];
        dp[0] = 1;
        dp[1] = 1;
        dp[2] = 2;
        for (int i = 3; i <= N; ++i) {
            dp[i] = (dp[i - 1] * 2 + dp[i - 3]) % 1000000007;
        }
        return (int)dp[N];
    }
}
// @lc code=end

