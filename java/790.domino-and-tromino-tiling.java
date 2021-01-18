/*
 * @lc app=leetcode id=790 lang=java
 *
 * [790] Domino and Tromino Tiling
 */

// @lc code=start
class Solution {
    public int numTilings(int N) {
        int[] dp = new int[N + 2];
        dp[0] = 1;
        dp[1] = 1;
        dp[2] = 2;
        for (int i = 3; i <= N; ++i) {
            dp[i] = (int)(((long)dp[i - 1] * 2 + (long)dp[i - 3]) % 1000000007);
        }
        return dp[N];
    }
}
// @lc code=end

