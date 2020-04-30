/*
 * @lc app=leetcode id=909 lang=csharp
 *
 * [909] Snakes and Ladders
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int SnakesAndLadders(int[][] board) {
        int n = board.Length, d = n * n - 1, ret = 0;
        var flattened = board
            .Reverse()
            .SelectMany((row, i) => i % 2 == 0 ? row : row.Reverse())
            .ToArray();
        var visited = new HashSet<int>();
        var queue = new Queue<int>();
        visited.Add(0);
        queue.Enqueue(0);
        while (queue.Count > 0) {
            for (int i = queue.Count; i > 0; --i) {
                int curr = queue.Dequeue();
                if (curr == d) {
                    return ret;
                }
                for (int j = 1; j <= 6; ++j) {
                    int next = curr + j;
                    if (next > d) {
                        continue;
                    }
                    if (flattened[next] > 0) {
                        next = flattened[next] - 1;
                    }
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

