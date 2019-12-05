/*
 * @lc app=leetcode id=718 lang=csharp
 *
 * [718] Maximum Length of Repeated Subarray
 */

// @lc code=start
public class Solution {
    public int FindLength(int[] A, int[] B) {
        int m = A.Length, n = B.Length, ret = 0;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; ++i) {
            for (int j = 1; j <= n; ++j) {
                if (A[i - 1] == B[j - 1])
                {
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                    ret = Math.Max(ret, dp[i, j]);
                }
            }
        }
        return ret;
    }
}
// @lc code=end

