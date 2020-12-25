/*
 * @lc app=leetcode id=1617 lang=csharp
 *
 * [1617] Count Subtrees With Max Distance Between Cities
 */

using System;

// @lc code=start
public class Solution {

    private static int GetSubtreeDistance(int n, int nodes, int[,] dist) {
        int e = 0, v = 0, ret = 0;
        for (int i = 0; i < n; ++i) {
            if ((nodes & (1 << i)) == 0) {
                continue;
            }
            ++v;
            for (int j = i + 1; j < n; ++j) {
                if ((nodes & (1 << j)) == 0) {
                    continue;
                }
                ret = Math.Max(dist[i, j], ret);
                if (dist[i, j] == 1) {
                    ++e;
                }
            }
        }
        return e == v - 1 ? ret : 0;
    }

    public int[] CountSubgraphsForEachDiameter(int n, int[][] edges) {
        var dist = new int[n, n];
        var ret = new int[n - 1];
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                dist[i, j] = n;
            }
        }
        foreach (var edge in edges) {
            int a = edge[0] - 1, b = edge[1] - 1;
            dist[a, b] = 1;
            dist[b, a] = 1;
        }
        for (int k = 0; k < n; ++k) {
            for (int i = 0; i < n; ++i) {
                for (int j = 0; j < n; ++j) {
                    dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                }
            }
        }
        for (int i = (1 << n) - 1; i > 0; --i) {
            int d = GetSubtreeDistance(n, i, dist);
            if (d > 0) {
                ++ret[d - 1];
            }
        }
        return ret;
    }
}
// @lc code=end
