/*
 * @lc app=leetcode id=650 lang=csharp
 *
 * [650] 2 Keys Keyboard
 */

// @lc code=start
public class Solution {
    public int MinSteps(int n) {
        int[] dp = new int[n + 1];
        for (int i = 2; i <= n; ++i) {
            dp[i] = i;
            for (int j = i - 1; j > 1; --j) {
                if (i % j == 0) {
                    dp[i] = dp[j] + i / j;
                    break;
                }
            }
        }
        return dp[n];
    }
}
// @lc code=end

