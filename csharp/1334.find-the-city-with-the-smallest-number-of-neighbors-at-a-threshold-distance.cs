/*
 * @lc app=leetcode id=1334 lang=csharp
 *
 * [1334] Find the City With the Smallest Number of Neighbors at a Threshold Distance
 */

using System;

// @lc code=start
public class Solution {
    public int FindTheCity(int n, int[][] edges, int distanceThreshold) {
        var dist = new int[n, n];
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                dist[i, j] = 100000;
            }
            dist[i, i] = 0;
        }
        foreach (var edge in edges) {
            int a = edge[0], b = edge[1], d = edge[2];
            dist[a, b] = d;
            dist[b, a] = d;
        }
        for (int m = 0; m < n; ++m) {
            for (int i = 0; i < n; ++i) {
                for (int j = 0; j < n; ++j) {
                    dist[i, j] = Math.Min(dist[i, j], dist[i, m] + dist[m, j]);
                }
            }
        }
        int minCount = int.MaxValue, ret = -1;
        for (int i = 0; i < n; ++i) {
            int count = 0;
            for (int j = 0; j < n; ++j) {
                if (dist[i, j] <= distanceThreshold) {
                    ++count;
                }
            }
            if (count <= minCount) {
                minCount = count;
                ret = i;
            }
        }
        return ret;
    }
}
// @lc code=end

