/*
 * @lc app=leetcode id=1494 lang=java
 *
 * [1494] Parallel Courses II
 */

// @lc code=start
class Solution {
    public int minNumberOfSemesters(int n, int[][] relations, int k) {
        int[] deps = new int[n];
        int t = 1 << n;
        int[] dp = new int[t];
        for (int[] relation : relations) {
            deps[relation[1] - 1] |= 1 << (relation[0] - 1);
        }
        for (int i = 1; i < t; ++i) {
            dp[i] = n;
        }
        for (int curr = 0; curr < t; ++curr) {
            int canTake = 0;
            for (int i = 0; i < n; ++i) {
                if ((deps[i] & curr) == deps[i]) {
                    canTake |= 1 << i;
                }
            }
            canTake &= ~curr;
            for (int take = canTake; take != 0; take = (take - 1) & canTake) {
                int count = 0, l = take;
                while (l != 0) {
                    count += l & 1;
                    l >>= 1;
                }
                if (count <= k) {
                    dp[curr | take] = Math.min(dp[curr | take], 1 + dp[curr]);
                }
            }
        }
        return dp[t - 1];
    }
}
// @lc code=end

