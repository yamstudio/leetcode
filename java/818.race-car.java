/*
 * @lc app=leetcode id=818 lang=java
 *
 * [818] Race Car
 */

// @lc code=start
class Solution {
    public int racecar(int target) {
        int[] dp = new int[target + 1];
        for (int i = 1; i <= target; ++i) {
            dp[i] = Integer.MAX_VALUE;
            int j, as;
            for (j = 1, as = 1; j < i; ++as, j = (j << 1) | 1) {
                for (int k = 0, rs = 0; k < j; ++rs, k = (k << 1) | 1) {
                    dp[i] = Math.min(dp[i], as + rs + 2 + dp[i - j + k]);
                }
            }
            dp[i] = Math.min(dp[i], as + (i == j ? 0 : 1 + dp[j - i]));
        }
        return dp[target];
    }
}
// @lc code=end

