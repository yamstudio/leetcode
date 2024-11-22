/*
 * @lc app=leetcode id=935 lang=java
 *
 * [935] Knight Dialer
 */

import java.util.Collections;
import java.util.Map;
import java.util.Set;

// @lc code=start
class Solution {
    private static final Map<Integer, Set<Integer>> MOVE = Map.of(
        0, Set.of(4, 6),
        1, Set.of(6, 8),
        2, Set.of(7, 9),
        3, Set.of(4, 8),
        4, Set.of(0, 3, 9),
        5, Collections.emptySet(),
        6, Set.of(0, 1, 7),
        7, Set.of(2, 6),
        8, Set.of(1, 3),
        9, Set.of(2, 4)
    );

    public int knightDialer(int n) {
        int[][] dp = new int[2][10];
        int r = 0;
        for (int i = 0; i < 10; ++i) {
            dp[0][i] = 1;
        }
        for (int i = 1; i < n; ++i) {
            r = 1 - r;
            for (int j = 0; j < 10; ++j) {
                dp[r][j] = 0;
                for (int prev : MOVE.get(j)) {
                    dp[r][j] = (dp[r][j] + dp[1 - r][prev]) % 1000000007;
                }
            }
        }
        int ret = 0;
        for (int i = 0; i < 10; ++i) {
            ret = (ret + dp[r][i]) % 1000000007;
        }
        return ret;
    }
}
// @lc code=end

