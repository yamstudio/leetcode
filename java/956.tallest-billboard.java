/*
 * @lc app=leetcode id=956 lang=java
 *
 * [956] Tallest Billboard
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int tallestBillboard(int[] rods) {
        int n = rods.length, s = Arrays.stream(rods).sum();
        int dp[] = new int[s + 1];
        for (int i = 1; i <= s; ++i) {
            dp[i] = -1;
        }
        int prev[] = new int[s + 1];
        for (int r : rods) {
            for (int i = 0; i <= s; ++i) {
                prev[i] = dp[i];
            }
            for (int i = 0; i <= s; ++i) {
                if (prev[i] < 0) {
                    continue;
                }
                dp[i + r] = Math.max(dp[i + r], prev[i]);
                dp[Math.abs(i - r)] = Math.max(dp[Math.abs(i - r)], prev[i] + Math.min(r, i));
            }
        }
        return dp[0];
    }
}
// @lc code=end

