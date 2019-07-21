/*
 * @lc app=leetcode id=120 lang=csharp
 *
 * [120] Triangle
 */
public class Solution {
    public int MinimumTotal(IList<IList<int>> triangle) {
        int n = triangle.Count, ret = int.MaxValue;
        if (n == 0) {
            return 0;
        }
        int[] dp = new int[n];
        dp[0] = triangle[0][0];
        for (int i = 1; i < n; ++i) {
            int prev = dp[0];
            dp[0] = triangle[i][0] + prev;
            for (int j = 1; j < i; ++j) {
                int tmp = dp[j];
                dp[j] = triangle[i][j] + Math.Min(prev, tmp);
                prev = tmp;
            }
            dp[i] = triangle[i][i] + prev;
        }
        for (int i = 0; i < n; ++i) {
            ret = Math.Min(dp[i], ret);
        }
        return ret;
    }
}

