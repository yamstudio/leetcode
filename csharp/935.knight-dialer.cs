/*
 * @lc app=leetcode id=935 lang=csharp
 *
 * [935] Knight Dialer
 */

// @lc code=start
public class Solution {

    private static int[][] Paths = new int[][] {
        new int[] { 4, 6 },
        new int[] { 6, 8 },
        new int[] { 7, 9 },
        new int[] { 4, 8 },
        new int[] { 0, 3, 9 },
        new int[] {},
        new int[] { 0, 1, 7 },
        new int[] { 2, 6 },
        new int[] { 1, 9 },
        new int[] { 2, 4 }
    };

    public int KnightDialer(int N) {
        int r = 0, ret = 0;
        int[,] dp = new int[2, 10];
        for (int j = 0; j < 10; ++j) {
            dp[1, j] = 1;
        }
        for (int i = 1; i < N; ++i) {
            for (int j = 0; j < 10; ++j) {
                dp[r, j] = 0;
                foreach (int k in Paths[j]) {
                    dp[r, j] = (dp[r, j] + dp[1 - r, k]) % 1000000007;
                }
            }
            r = 1 - r;
        }
        for (int j = 0; j < 10; ++j) {
            ret = (ret + dp[1 - r, j]) % 1000000007;
        }
        return ret;
    }
}
// @lc code=end

