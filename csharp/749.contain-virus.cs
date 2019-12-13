/*
 * @lc app=leetcode id=749 lang=csharp
 *
 * [749] Contain Virus
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static IEnumerable<(int r, int c)> GetNeighbors(int r, int c) {
        yield return (r: r - 1, c: c);
        yield return (r: r + 1, c: c);
        yield return (r: r, c: c - 1);
        yield return (r: r, c: c + 1);
    }

    public int ContainVirus(int[][] grid) {
        int ret = 0, m = grid.Length, n = grid[0].Length;
        Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
        var list = new List<(int count, IList<(int r, int c)> virus, IList<(int r, int c)> wall)>();
        while (true) {
            bool[,] visited = new bool[m, n];
            list.Clear();
            for (int r = 0; r < m; ++r) {
                for (int c = 0; c < n; ++c) {
                    if (grid[r][c] != 1 || visited[r, c]) {
                        continue;
                    }
                    var virus = new List<(int r, int c)>();
                    var wall = new List<(int r, int c)>();
                    virus.Add((r: r, c: c));
                    queue.Clear();
                    queue.Enqueue((r: r, c: c));
                    visited[r, c] = true;
                    while (queue.Count > 0) {
                        var curr = queue.Dequeue();
                        foreach (var neighbor in GetNeighbors(curr.r, curr.c)) {
                            int nr = neighbor.r, nc = neighbor.c;
                            if (nr < 0 || nr >= m || nc < 0 || nc >= n || grid[nr][nc] < 0 || visited[nr, nc]) {
                                continue;
                            }
                            if (grid[nr][nc] == 1) {
                                virus.Add(neighbor);
                                visited[nr, nc] = true;
                                queue.Enqueue(neighbor);
                            } else {
                                wall.Add(neighbor);
                            }
                        }
                    }
                    list.Add((count: wall.Distinct().Count(), virus: virus, wall: wall));
                }
            }
            int k = list.Count;
            if (k == 0) {
                break;
            }
            list.Sort(Comparer<(int count, IList<(int r, int c)> virus, IList<(int r, int c)> wall)>.Create((a, b) => b.count.CompareTo(a.count)));
            ret += list[0].wall.Count;
            foreach (var curr in list[0].virus) {
                grid[curr.r][curr.c] = -1;
            }
            for (int i = 1; i < k; ++i) {
                foreach (var curr in list[i].wall) {
                    grid[curr.r][curr.c] = 1;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

