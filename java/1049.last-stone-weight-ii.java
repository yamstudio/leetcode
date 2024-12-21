/*
 * @lc app=leetcode id=1049 lang=java
 *
 * [1049] Last Stone Weight II
 */

// @lc code=start
class Solution {
    public int lastStoneWeightII(int[] stones) {
        int sum = 0;
        for (int s : stones) {
            sum += s;
        }
        int half = sum / 2;
        boolean[] dp = new boolean[half + 1];
        dp[0] = true;
        for (int s : stones) {
            for (int t = half; t >= s; --t) {
                dp[t] |= dp[t - s];
            }
        }
        for (int t = half; t >= 0; --t) {
            if (dp[t]) {
                return sum - 2 * t;
            }
        }
        throw new IllegalStateException();
    }
}
// @lc code=end

