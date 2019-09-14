/*
 * @lc app=leetcode id=407 lang=csharp
 *
 * [407] Trapping Rain Water II
 */

using System.Collections.Generic;

public class Solution {

    private static readonly (int, int)[] Dirs = new (int, int)[] 
    {
        (-1, 0), (1, 0), (0, -1), (0, 1),
    };

    public int TrapRainWater(int[][] heightMap) {
        int m = heightMap.Length, n, ret = 0, max = 0;
        if (m == 0) {
            return 0;
        }
        n = heightMap[0].Length;
        SortedSet<(int, int, int)> sorted = new SortedSet<(int, int, int)>(Comparer<(int, int, int)>.Create((a, b) => a.Item3 == b.Item3 ? (a.Item2 == b.Item2 ? a.Item1.CompareTo(b.Item1) : a.Item2.CompareTo(b.Item2)) : a.Item3.CompareTo(b.Item3)));
        bool[,] visited = new bool[m, n];
        for (int j = 0; j < n; ++j) {
            visited[0, j] = true;
            visited[m - 1, j] = true;
            sorted.Add((0, j, heightMap[0][j]));
            sorted.Add((m - 1, j, heightMap[m - 1][j]));
        }
        for (int i = 1; i < m - 1; ++i) {
            visited[i, 0] = true;
            visited[i, n - 1] = true;
            sorted.Add((i, 0, heightMap[i][0]));
            sorted.Add((i, n - 1, heightMap[i][n - 1]));
        }

        while (sorted.Count > 0) {
            var curr = sorted.Min;
            sorted.Remove(curr);
            int x = curr.Item1, y = curr.Item2;
            max = Math.Max(max, curr.Item3);
            foreach (var dir in Dirs) {
                int nx = x + dir.Item1, ny = y + dir.Item2;
                if (nx < 0 || nx >= m || ny < 0 || ny >= n || visited[nx, ny]) {
                    continue;
                }
                if (heightMap[nx][ny] < max) {
                    ret += max - heightMap[nx][ny];
                }
                visited[nx, ny] = true;
                sorted.Add((nx, ny, heightMap[nx][ny]));
            }
        }

        return ret;
    }
}

