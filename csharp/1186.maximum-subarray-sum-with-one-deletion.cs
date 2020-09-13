/*
 * @lc app=leetcode id=1186 lang=csharp
 *
 * [1186] Maximum Subarray Sum with One Deletion
 */

using System;

// @lc code=start
public class Solution {
    public int MaximumSum(int[] arr) {
        int n = arr.Length, ret = int.MinValue;
        int[,] dp = new int[2, n + 1];
        dp[0, 0] = -100000;
        dp[1, 0] = -100000;
        for (int i = 0; i < n; ++i) {
            int curr = arr[i];
            dp[0, i + 1] = curr + Math.Max(0, dp[0, i]);
            dp[1, i + 1] = Math.Max(dp[0, i], curr + dp[1, i]);
            ret = Math.Max(ret, Math.Max(dp[0, i + 1], dp[1, i + 1]));
        }
        return ret;
    }
}
// @lc code=end

