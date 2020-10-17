/*
 * @lc app=leetcode id=1345 lang=csharp
 *
 * [1345] Jump Game IV
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int MinJumps(int[] arr) {
        var values = arr
            .Select((x, i) => (Value: x, Index: i))
            .GroupBy(t => t.Value, (x, a) => (Value: x, Indices: a.Select(t => t.Index).ToList()))
            .ToDictionary(t => t.Value, t => t.Indices);
        var queue = new Queue<int>();
        int ret = 0, n = arr.Length;
        var visited = new bool[n];
        visited[0] = true;
        queue.Enqueue(0);
        while (queue.Any()) {
            for (int i = queue.Count; i > 0; --i) {
                var curr = queue.Dequeue();
                if (curr == n - 1) {
                    return ret;
                }
                var val = arr[curr];
                foreach (var next in values[val].Append(curr - 1).Append(curr + 1).Where(x => x >= 0 && x < n)) {
                    if (!visited[next]) {
                        visited[next] = true;
                        queue.Enqueue(next);
                    }
                }
                values[val].Clear();
            }
            ++ret;
        }
        return -1;
    }
}
// @lc code=end

