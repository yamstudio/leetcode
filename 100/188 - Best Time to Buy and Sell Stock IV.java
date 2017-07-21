public class Solution {
    public int maxProfit(int k, int[] prices) {
        int ret = 0, i, j, local;
        int[][] dp;
        
        if (k >= prices.length / 2) {
            for (i = 1; i < prices.length; ++i) {
                if (prices[i] > prices[i - 1])
                    ret += prices[i] - prices[i - 1];
            }
            return ret;
        }
        
        dp = new int[k + 1][prices.length];
        for (i = 1; i <= k; ++i) {
            local = dp[i - 1][0] - prices[0];
            for (j = 1; j < prices.length; ++j) {
                dp[i][j] = Math.max(dp[i][j - 1], prices[j] + local);
                local = Math.max(local, dp[i - 1][j] - prices[j]);
            }
        }
        
        return dp[k][prices.length - 1];
    }
}
