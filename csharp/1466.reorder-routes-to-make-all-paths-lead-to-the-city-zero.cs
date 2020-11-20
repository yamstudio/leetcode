/*
 * @lc app=leetcode id=1466 lang=csharp
 *
 * [1466] Reorder Routes to Make All Paths Lead to the City Zero
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int MinReorder(int n, int[][] connections) {
        int ret = 0;
        var queue = new Queue<int>();
        var map = new Dictionary<int, HashSet<int>>();
        foreach (var t in connections) {
            int from = t[0] + 1, to = t[1] + 1;
            if (!map.TryGetValue(from, out var fm)) {
                fm = new HashSet<int>();
                map[from] = fm;
            }
            if (!map.TryGetValue(to, out var tm)) {
                tm = new HashSet<int>();
                map[to] = tm;
            }
            fm.Add(to);
            tm.Add(-from);
        }
        map[0] = new HashSet<int>() { -1 };
        queue.Enqueue(0);
        while (queue.Count > 0) {
            int curr = queue.Dequeue();
            foreach (var next in map[curr]) {
                if (next > 0) {
                    ++ret;
                    queue.Enqueue(next);
                    map[next].Remove(-curr);
                } else {
                    queue.Enqueue(-next);
                    map[-next].Remove(curr);
                }
            }
        }
        return ret;
    }
}
// @lc code=end

