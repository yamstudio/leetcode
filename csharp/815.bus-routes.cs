/*
 * @lc app=leetcode id=815 lang=csharp
 *
 * [815] Bus Routes
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int NumBusesToDestination(int[][] routes, int S, int T) {
        int n = routes.Length, ret = 0;
        var visited = new HashSet<int>();
        var map = new Dictionary<int, HashSet<int>>();
        var queue = new Queue<int>();
        for (int bus = 0; bus < n; ++bus) {
            foreach (var stop in routes[bus]) {
                HashSet<int> set;
                if (!map.TryGetValue(stop, out set)) {
                    set = new HashSet<int>();
                    map[stop] = set;
                }
                set.Add(bus);
            }
        }
        queue.Enqueue(S);
        visited.Add(S);
        while (queue.Count != 0) {
            for (int i = queue.Count - 1; i >= 0; --i) {
                int curr = queue.Dequeue();
                if (curr == T) {
                    return ret;
                }
                HashSet<int> buses;
                if (!map.TryGetValue(curr, out buses)) {
                    continue;
                }
                foreach (int bus in buses) {
                    foreach (var next in routes[bus]) {
                        if (!visited.Add(next)) {
                            continue;
                        }
                        queue.Enqueue(next);
                    }
                }
            }
            ++ret;
        }
        return -1;
    }
}
// @lc code=end

