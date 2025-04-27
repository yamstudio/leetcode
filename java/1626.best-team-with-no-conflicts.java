/*
 * @lc app=leetcode id=1626 lang=java
 *
 * [1626] Best Team With No Conflicts
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int bestTeamScore(int[] scores, int[] ages) {
        int n = scores.length;
        Pair[] pairs = new Pair[n];
        for (int i = 0; i < n; ++i) {
            pairs[i] = new Pair(ages[i], scores[i]);
        }
        Arrays.sort(pairs, java.util.Comparator.comparingInt(Pair::age).thenComparing(Pair::score).reversed());
        int ret = 0;
        int[] dp = new int[n];
        for (int i = 0; i < n; ++i) {
            Pair p = pairs[i];
            int score = p.score();
            dp[i] = score;
            for (int j = 0; j < i; ++j) {
                if (pairs[j].score() >= score) {
                    dp[i] = Math.max(dp[i], score + dp[j]);
                }
            }
            ret = Math.max(dp[i], ret);
        }
        return ret;
    }

    private record Pair(int age, int score) {}
}
// @lc code=end

