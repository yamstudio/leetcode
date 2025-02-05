/*
 * @lc app=leetcode id=1320 lang=java
 *
 * [1320] Minimum Distance to Type a Word Using Two Fingers
 */

// @lc code=start
class Solution {
    public int minimumDistance(String word) {
        return minimumDistanceRecurse(word, 0, 26, 26, new int[27][27][word.length()]);
    }

    private static int minimumDistanceRecurse(String word, int i, int l, int r, int[][][] memo) {
        if (i == word.length()) {
            return 0;
        }
        int v = memo[l][r][i];
        if (v == 0) {
            int c = word.charAt(i) - 'A';
            v = 1 + Math.min(getCost(l, c) + minimumDistanceRecurse(word, i + 1, c, r, memo), getCost(r, c) + minimumDistanceRecurse(word, i + 1, l, c, memo));
            memo[l][r][i] = v;
            memo[r][l][i] = v;
        }
        return v - 1;
    }

    private static int getCost(int a, int b) {
        if (a == 26) {
            return 0;
        }
        return Math.abs(a % 6 - b % 6) + Math.abs(a / 6 - b / 6);
    }
}
// @lc code=end

