/*
 * @lc app=leetcode id=174 lang=csharp
 *
 * [174] Dungeon Game
 */
public class Solution {
    public int CalculateMinimumHP(int[][] dungeon) {
        int m = dungeon.Length;
        if (m == 0) {
            return 0;
        }
        int n = dungeon[0].Length;
        int[] dp = new int[n + 1];
        for (int i = 0; i <= n; ++i) {
            dp[i] = int.MaxValue;
        }
        dp[n - 1] = 1;
        for (int i = m - 1; i >= 0; --i) {
            for (int j = n - 1; j >= 0; --j) {
                dp[j] = Math.Max(1, Math.Min(dp[j], dp[j + 1]) - dungeon[i][j]);
            }
        }
        return dp[0];
    }
}

