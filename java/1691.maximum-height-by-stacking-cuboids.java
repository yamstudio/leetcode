/*
 * @lc app=leetcode id=1691 lang=java
 *
 * [1691] Maximum Height by Stacking Cuboids 
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int maxHeight(int[][] cuboids) {
        int n = cuboids.length, ret = 0;
        for (int[] c : cuboids) {
            Arrays.sort(c);
        }
        Arrays.sort(
            cuboids, 
            java.util.Comparator
                .comparingInt((int[] c) -> c[0])
                .thenComparingInt((int[] c) -> c[1])
                .thenComparingInt((int[] c) -> c[2])
                .reversed());
        int[] dp = new int[n];
        for  (int i = 0; i < n; ++i) {
            dp[i] = cuboids[i][2];
            for (int j = 0; j < i; ++j) {
                if (cuboids[j][0] >= cuboids[i][0] && cuboids[j][1] >= cuboids[i][1] && cuboids[j][2] >= cuboids[i][2]) {
                    dp[i] = Math.max(dp[i], dp[j] + cuboids[i][2]);
                }
            }
            ret = Math.max(dp[i], ret);
        }
        return ret;
    }
}
// @lc code=end

