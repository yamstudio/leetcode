/*
 * @lc app=leetcode id=1617 lang=java
 *
 * [1617] Count Subtrees With Max Distance Between Cities
 */

// @lc code=start
class Solution {
    public int[] countSubgraphsForEachDiameter(int n, int[][] edges) {
        int[][] dist = new int[n][n];
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                dist[i][j] = n;
            }
        }
        for (int[] edge : edges) {
            int i = edge[0] - 1, j = edge[1] - 1;
            dist[i][j] = 1;
            dist[j][i] = 1;
        }
        for (int k = 0; k < n; ++k) {
            for (int i = 0; i < n; ++i) {
                for (int j = 0; j < n; ++j) {
                    dist[i][j] = Math.min(dist[i][j], dist[i][k] + dist[k][j]);
                }
            }
        }
        int[] ret = new int[n - 1];
        for (int vs = (1 << n) - 1; vs > 0; --vs) {
            int d = getDistance(vs, dist);
            if (d > 0) {
                ++ret[d - 1];
            }
        }
        return ret;
    }

    private static int getDistance(int vs, int[][] dist) {
        int v = 0, edges = 0, ret = 0, n = dist.length;
        for (int i = 0; i < n; ++i) {
            if ((vs & (1 << i)) == 0) {
                continue;
            }
            ++v;
            for (int j = i + 1; j < n; ++j) {
                if ((vs & (1 << j)) == 0) {
                    continue;
                }
                ret = Math.max(ret, dist[i][j]);
                if (dist[i][j] == 1) {
                    ++edges;
                }
            }
        }
        return edges == v - 1 ? ret : -1;
    }
}
// @lc code=end

