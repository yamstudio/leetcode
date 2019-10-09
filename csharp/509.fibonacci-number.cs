/*
 * @lc app=leetcode id=509 lang=csharp
 *
 * [509] Fibonacci Number
 */

// @lc code=start
public class Solution {
    public int Fib(int N) {
        int[] dp = new int[N + 2];
        dp[1] = 1;
        for (int i = 2; i <= N; ++i) {
            dp[i] = dp[i - 1] + dp[i - 2];
        }
        return dp[N];
    }
}
// @lc code=end

