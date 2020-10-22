/*
 * @lc app=leetcode id=1359 lang=csharp
 *
 * [1359] Count All Valid Pickup and Delivery Options
 */

// @lc code=start
public class Solution {
    public int CountOrders(int n) {
        int[] dp = new int[n + 1];
        dp[0] = 1;
        for (int i = 1; i <= n; ++i) {
            long slots = 2 * i - 1, picks = slots * (slots + 1) / 2;
            dp[i] = (int)((long)dp[i - 1] * picks % 1000000007);
        }
        return dp[n];
    }
}
// @lc code=end

