/*
 * @lc app=leetcode id=1030 lang=csharp
 *
 * [1030] Matrix Cells in Distance Order
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static (int DR, int DC)[] Dirs = new (int DR, int DC)[] {
        (DR: -1, DC: 0),
        (DR: 1, DC: 0),
        (DR: 0, DC: -1),
        (DR: 0, DC: 1)
    };

    public int[][] AllCellsDistOrder(int R, int C, int r0, int c0) {
        var visited = new HashSet<(int Row, int Col)>();
        var queue = new Queue<(int Row, int Col)>();
        var ret = new int[R * C][];
        int i = 0;
        visited.Add((Row: r0, Col: c0));
        queue.Enqueue((Row: r0, Col: c0));
        while (queue.Count > 0) {
            for (int j = queue.Count; j > 0; --j) {
                var curr = queue.Dequeue();
                ret[i++] = new int[] { curr.Row, curr.Col };
                foreach (var dir in Dirs) {
                    int nr = dir.DR + curr.Row, nc = dir.DC + curr.Col;
                    if (nr < 0 || nr >= R || nc < 0 || nc >= C) {
                        continue;
                    }
                    var key = (Row: nr, Col: nc);
                    if (visited.Contains(key)) {
                        continue;
                    }
                    visited.Add(key);
                    queue.Enqueue(key);
                }
            }
        }
        return ret;
    }
}
// @lc code=end

