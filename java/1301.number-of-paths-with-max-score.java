/*
 * @lc app=leetcode id=1301 lang=java
 *
 * [1301] Number of Paths with Max Score
 */

import java.util.List;

// @lc code=start
class Solution {
    public int[] pathsWithMaxScore(List<String> board) {
        int n = board.size(), d = 0;
        int[][][] dp = new int[2][n][2];
        for (int i = n - 1; i >= 0; --i) {
            String row = board.get(i);
            for (int j = n - 1; j >= 0; --j) {
                dp[d][j][0] = 0;
                dp[d][j][1] = 0;
                char c = row.charAt(j);
                if (c == 'X') {
                    continue;
                }
                if (c == 'S') {
                    dp[d][j][1] = 1;
                    continue;
                }
                if (j < n - 1) {
                    dp[d][j][0] = dp[d][j + 1][0];
                    dp[d][j][1] = dp[d][j + 1][1];
                    if (i < n - 1) {
                        if (dp[d][j][0] < dp[1 - d][j + 1][0]) {
                            dp[d][j][0] = dp[1 - d][j + 1][0];
                            dp[d][j][1] = dp[1 - d][j + 1][1];
                        } else if (dp[d][j][0] == dp[1 - d][j + 1][0]) {
                            dp[d][j][1] = (dp[d][j][1] + dp[1 - d][j + 1][1]) % 1000000007;
                        }
                    }
                }
                if (i < n - 1) {
                    if (dp[d][j][0] < dp[1 - d][j][0]) {
                        dp[d][j][0] = dp[1 - d][j][0];
                        dp[d][j][1] = dp[1 - d][j][1];
                    } else if (dp[d][j][0] == dp[1 - d][j][0]) {
                        dp[d][j][1] = (dp[d][j][1] + dp[1 - d][j][1]) % 1000000007;
                    }
                }
                if (dp[d][j][1] == 0) {
                    dp[d][j][0] = 0;
                } else if (i != 0 || j != 0) {
                    dp[d][j][0] += c - '0';
                }
            }
            d = 1 - d;
        }
        return dp[1 - d][0];
    }
}
// @lc code=end

