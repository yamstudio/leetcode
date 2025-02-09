/*
 * @lc app=leetcode id=1340 lang=java
 *
 * [1340] Jump Game V
 */

// @lc code=start
class Solution {
    public int maxJumps(int[] arr, int d) {
        int n = arr.length, ret = 1;
        int[] dp = new int[n];
        for (int i = 0; i < n; ++i) {
            ret = Math.max(ret, maxJumps(arr, i, d, dp));
        }
        return ret;
    }

    private static int maxJumps(int[] arr, int i, int d, int[] dp) {
        if (dp[i] != 0) {
            return dp[i];
        }
        int ret = 1, n = arr.length;
        for (int j = i + 1; j < n && j <= i + d && arr[j] < arr[i]; ++j) {
            ret = Math.max(ret, 1 + maxJumps(arr, j, d, dp));
        }
        for (int j = i - 1; j >= 0 && j >= i - d && arr[j] < arr[i]; --j) {
            ret = Math.max(ret, 1 + maxJumps(arr, j, d, dp));
        }
        dp[i] = ret;
        return ret;
    }
}
// @lc code=end

