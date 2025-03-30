/*
 * @lc app=leetcode id=1510 lang=java
 *
 * [1510] Stone Game IV
 */

// @lc code=start
class Solution {
    public boolean winnerSquareGame(int n) {
        return winnerSquareGame(n, new Boolean[n + 1]);
    }

    private static boolean winnerSquareGame(int n, Boolean[] memo) {
        Boolean m = memo[n];
        if (m != null) {
            return m;
        }
        int d = (int)Math.sqrt(n);
        if (d * d == n) {
            memo[n] = true;
            return true;
        }
        while (d > 0) {
            if (!winnerSquareGame(n - d * d, memo)) {
                memo[n] = true;
                return true;
            }
            --d;
        }
        memo[n] = false;
        return false;
    }
}
// @lc code=end

