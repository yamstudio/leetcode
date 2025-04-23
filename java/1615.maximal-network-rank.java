/*
 * @lc app=leetcode id=1615 lang=java
 *
 * [1615] Maximal Network Rank
 */

// @lc code=start
class Solution {
    public int maximalNetworkRank(int n, int[][] roads) {
        int[] count = new int[n];
        boolean[][] connected = new boolean[n][n];
        for (int[] r : roads) {
            int a = r[0], b = r[1];
            ++count[a];
            ++count[b];
            connected[a][b] = true;
            connected[b][a] = true;
        }
        int ret = 0;
        for (int i = 0; i < n; ++i) {
            for (int j = i + 1; j < n; ++j) {
                ret = Math.max(ret, count[i] + count[j] - (connected[i][j] ? 1 : 0));
            }
        }
        return ret;
    }
}
// @lc code=end

