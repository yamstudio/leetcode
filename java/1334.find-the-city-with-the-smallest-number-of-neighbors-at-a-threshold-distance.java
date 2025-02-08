/*
 * @lc app=leetcode id=1334 lang=java
 *
 * [1334] Find the City With the Smallest Number of Neighbors at a Threshold Distance
 */

// @lc code=start
class Solution {
    public int findTheCity(int n, int[][] edges, int distanceThreshold) {
        int[][] dist = new int[n][n];
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                dist[i][j] = 100000;
            }
            dist[i][i] = 0;
        }
        for (int[] edge : edges) {
            int i = edge[0], j = edge[1], w = edge[2];
            dist[i][j] = w;
            dist[j][i] = w;
        }
        for (int k = 0; k < n; ++k) {
            for (int j = 0; j < n; ++j) {
                for (int i = 0; i < n; ++i) {
                    dist[i][j] = Math.min(dist[i][j], dist[i][k] + dist[k][j]);
                }
            }
        }
        int min = n, ret = -1;
        for (int i = 0; i < n; ++i) {
            int c = 0;
            for (int j = 0; j < n; ++j) {
                if (dist[i][j] <= distanceThreshold) {
                    ++c;
                }
            }
            if (c <= min) {
                min = c;
                ret = i;
            }
        }
        return ret;
    }
}
// @lc code=end

