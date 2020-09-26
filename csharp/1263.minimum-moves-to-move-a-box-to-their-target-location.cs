/*
 * @lc app=leetcode id=1263 lang=csharp
 *
 * [1263] Minimum Moves to Move a Box to Their Target Location
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static (int R, int C)[] Dirs = new (int R, int C)[] {
        (R: -1, C: 0),
        (R: 1, C: 0),
        (R: 0, C: -1),
        (R: 0, C: 1)
    };

    public int MinPushBox(char[][] grid) {
        var queue = new Queue<((int R, int C) K, (int R, int C) B)>();
        var map = new Dictionary<((int R, int C) K, (int R, int C) B), int>();
        int kr = -1, kc = -1, br = -1, bc = -1, tr = -1, tc = -1, m = grid.Length, n = grid[0].Length, ret = int.MaxValue;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 'T') {
                    tr = i;
                    tc = j;
                } else if (grid[i][j] == 'B') {
                    br = i;
                    bc = j;
                } else if (grid[i][j] == 'S') {
                    kr = i;
                    kc = j;
                }
            }
        }
        queue.Enqueue((K: (R: kr, C: kc), B: (R: br, C: bc)));
        map[(K: (R: kr, C: kc), B: (R: br, C: bc))] = 0;
        while (queue.Count > 0) {
            var curr = queue.Dequeue();
            int steps = map[curr];
            if (steps >= ret) {
                continue;
            }
            if (curr.B.R == tr && curr.B.C == tc) {
                ret = steps;
                continue;
            }
            foreach (var dir in Dirs) {
                int nr = dir.R + curr.K.R, nc = dir.C + curr.K.C, nbr = curr.B.R, nbc = curr.B.C, ns = steps;
                if (nr < 0 || nr >= m || nc < 0 || nc >= n || grid[nr][nc] == '#') {
                    continue;
                }
                if (nr == nbr && nc == nbc) {
                    nbr += dir.R;
                    nbc += dir.C;
                    if (nbr < 0 || nbr >= m || nbc < 0 || nbc >= n || grid[nbr][nbc] == '#') {
                        continue;
                    }
                    ++ns;
                }
                var next = (K: (R: nr, C: nc), B: (R: nbr, C: nbc));
                if (map.TryGetValue(next, out int s) && s <= ns) {
                    continue;
                }
                map[next] = ns;
                queue.Enqueue(next);
            }
        }
        return ret == int.MaxValue ? -1 : ret;
    }
}
// @lc code=end

