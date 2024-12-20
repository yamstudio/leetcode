/*
 * @lc app=leetcode id=1043 lang=java
 *
 * [1043] Partition Array for Maximum Sum
 */

// @lc code=start
class Solution {
    public int maxSumAfterPartitioning(int[] arr, int k) {
        int n = arr.length;
        int[] dp = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            int max = arr[i];
            for (int d = 1; d <= k && i - d + 1 >= 0; ++d) {
                max = Math.max(max, arr[i - d + 1]);
                dp[i + 1] = Math.max(dp[i + 1], dp[i - d + 1] + d * max);
            }
        }
        return dp[n];
    }
}
// @lc code=end

