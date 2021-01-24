/*
 * @lc app=leetcode id=808 lang=java
 *
 * [808] Soup Servings
 */

// @lc code=start
class Solution {

    private static double soupServings(int a, int b, double[][] memo) {
        if (a <= 0) {
            return b <= 0 ? 0.5 : 1.0;
        }
        if (b <= 0) {
            return 0.0;
        }
        if (memo[a][b] != 0) {
            return memo[a][b];
        }
        return memo[a][b] = 0.25 * (soupServings(a - 4, b, memo) + soupServings(a - 3, b - 1, memo) + soupServings(a - 2, b - 2, memo) + soupServings(a - 1, b - 3, memo));
    }

    public double soupServings(int N) {
        if (N >= 4500) {
            return 1.0;
        }
        return soupServings((N + 24) / 25, (N + 24) / 25, new double[180][180]);
    }
}
// @lc code=end

