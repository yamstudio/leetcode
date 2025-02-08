/*
 * @lc app=leetcode id=1335 lang=java
 *
 * [1335] Minimum Difficulty of a Job Schedule
 */

// @lc code=start
class Solution {
    public int minDifficulty(int[] jobDifficulty, int d) {
        int n = jobDifficulty.length;
        if (n < d) {
            return -1;
        }
        int[] curr = new int[n], prev = new int[n];
        prev[0] = jobDifficulty[0];
        for (int i = 1; i < n; ++i) {
            prev[i] = Math.max(prev[i - 1], jobDifficulty[i]);
        }
        for (int t = 1; t < d; ++t) {
            for (int i = t; i < n; ++i) {
                curr[i] = Integer.MAX_VALUE;
                int max = jobDifficulty[i];
                for (int p = i; p >= t; --p) {
                    max = Math.max(max, jobDifficulty[p]);
                    curr[i] = Math.min(curr[i], max + prev[p - 1]);
                }
            }
            int[] tmp = prev;
            prev = curr;
            curr = tmp;
        }
        return prev[n - 1];
    }
}
// @lc code=end

