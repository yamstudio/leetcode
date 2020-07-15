/*
 * @lc app=leetcode id=934 lang=csharp
 *
 * [934] Shortest Bridge
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static (int Row, int Col)[] Dirs = new (int Row, int Col)[] {
        (Row: -1, Col: 0),
        (Row: 1, Col: 0),
        (Row: 0, Col: -1),
        (Row: 0, Col: 1)
    };

    private static void AddIsland(int[][] A, int m, int n, int r, int c, Queue<(int Row, int Col)> queue, HashSet<(int Row, int Col)> visited) {
        if (r < 0 || r >= m || c < 0 || c >= n || A[r][c] == 0) {
            return;
        }
        var curr = (Row: r, Col: c);
        if (visited.Contains(curr)) {
            return;
        }
        queue.Enqueue(curr);
        visited.Add(curr);
        foreach (var dir in Dirs) {
            AddIsland(A, m, n, r + dir.Row, c + dir.Col, queue, visited);
        }
    }

    public int ShortestBridge(int[][] A) {
        int m = A.Length, n = A[0].Length, ret = 0;
        var queue = new Queue<(int Row, int Col)>();
        var visited = new HashSet<(int Row, int Col)>();
        for (int i = 0; i < m && queue.Count == 0; ++i) {
            for (int j = 0; j < n; ++j) {
                if (A[i][j] == 1) {
                    AddIsland(A, m, n, i, j, queue, visited);
                    break;
                }
            }
        }
        while (queue.Count > 0) {
            for (int c = queue.Count; c > 0; --c) {
                var curr = queue.Dequeue();
                foreach (var dir in Dirs) {
                    var next = (Row: curr.Row + dir.Row, Col: curr.Col + dir.Col);
                    if (next.Row < 0 || next.Row >= m || next.Col < 0 || next.Col >= n || visited.Contains(next)) {
                        continue;
                    }
                    if (A[next.Row][next.Col] == 1) {
                        return ret;
                    }
                    queue.Enqueue(next);
                    visited.Add(next);
                }
            }
            ++ret;
        }
        return -1;
    }
}
// @lc code=end

