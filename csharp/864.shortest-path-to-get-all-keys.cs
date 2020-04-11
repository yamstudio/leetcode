/*
 * @lc app=leetcode id=864 lang=csharp
 *
 * [864] Shortest Path to Get All Keys
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static (int Row, int Col)[] Directions = new (int Row, int Col)[] {
        (Row: -1, Col: 0),
        (Row: 1, Col: 0),
        (Row: 0, Col: -1),
        (Row: 0, Col: 1)
    };

    public int ShortestPathAllKeys(string[] grid) {
        int m = grid.Length, n = grid[0].Length, k = 0, ret = 0, target;
        var visited = new HashSet<(int Row, int Col, int State)>();
        var queue = new Queue<(int Row, int Col, int State)>();
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                char c = grid[i][j];
                if (c == '@') {
                    var start = (Row: i, Col: j, State: 0);
                    visited.Add(start);
                    queue.Enqueue(start);
                } else if (c >= 'a' && c <= 'f') {
                    ++k;
                }
            }
        }
        target = (1 << k) - 1;
        while (queue.Count > 0) {
            for (int i = queue.Count; i > 0; --i) {
                var curr = queue.Dequeue();
                int state = curr.State;
                char cell = grid[curr.Row][curr.Col];
                if (cell >= 'a' && cell <= 'f') {
                    state |= (1 << ((int)cell - (int)'a'));
                }
                if (state == target) {
                    return ret;
                }
                foreach (var dir in Directions) {
                    int nr = dir.Row + curr.Row, nc = dir.Col + curr.Col;
                    if (nr < 0 || nr >= m || nc < 0 || nc >= n) {
                        continue;
                    }
                    char nextCell = grid[nr][nc];
                    if (nextCell == '#') {
                        continue;
                    }
                    if (nextCell >= 'A' && nextCell <= 'F') {
                        if ((state & (1 << ((int)nextCell - (int)'A'))) == 0) {
                            continue;
                        }
                    }
                    var next = (Row: nr, Col: nc, State: state);
                    if (visited.Contains(next)) {
                        continue;
                    }
                    visited.Add(next);
                    queue.Enqueue(next);
                }
            }
            ++ret;
        }
        return -1;
    }
}
// @lc code=end

