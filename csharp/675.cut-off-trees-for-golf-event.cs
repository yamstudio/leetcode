/*
 * @lc app=leetcode id=675 lang=csharp
 *
 * [675] Cut Off Trees for Golf Event
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static readonly int[][] Dirs = new int[][] {
        new int[] { -1, 0, },
        new int[] { 1, 0, },
        new int[] { 0, -1, },
        new int[] { 0, 1, },
    };


    private static int Search(IList<IList<int>> forest, int m, int n, int r, int c, int tr, int tc) {
        if (r == tr && c == tc) {
            return 0;
        }
        bool[,] visited = new bool[m, n];
        Queue<(int Row, int Col)> queue = new Queue<(int Row, int Col)>();
        queue.Enqueue((Row: r, Col: c));
        int ret = 0;
        visited[r, c] = true;
        while (queue.Count > 0) {
            ++ret;
            int count = queue.Count;
            while (count-- > 0) {
                var curr = queue.Dequeue();
                foreach (var dir in Dirs) {
                    int nr = curr.Row + dir[0], nc = curr.Col + dir[1];
                    if (nr < 0 || nr == m || nc < 0 || nc == n || visited[nr, nc] || forest[nr][nc] == 0) {
                        continue;
                    }
                    if (nr == tr && nc == tc) {
                        return ret;
                    }
                    queue.Enqueue((Row: nr, Col: nc));
                    visited[nr, nc] = true;
                }
            }
        }
        return -1;
    }

    public int CutOffTree(IList<IList<int>> forest) {
        int m = forest.Count, n = forest[0].Count, ret = 0, r = 0, c = 0;
        foreach (var tree in forest.SelectMany((row, i) => row.Select((height, j) => (Height: height, Row: i, Col: j)).Where(tree => tree.Height > 0)).OrderBy(tree => tree.Height).ToArray()) {
            int tr = tree.Row, tc = tree.Col;
            int steps = Search(forest, m, n, r, c, tr, tc);
            if (steps < 0) {
                return -1;
            }
            ret += steps;
            r = tr;
            c = tc;
        }
        return ret;
    }
}
// @lc code=end

