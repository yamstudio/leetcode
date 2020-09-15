/*
 * @lc app=leetcode id=1192 lang=csharp
 *
 * [1192] Critical Connections in a Network
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    
    private static void CriticalConnectionsRecurse(IList<int>[] edges, int curr, int prev, IList<IList<int>> ret, int[] times, int[] minTimes, ref int t) {
        times[curr] = t;
        minTimes[curr] = t++;
        foreach (var next in edges[curr]) {
            if (times[next] == 0) {
                CriticalConnectionsRecurse(edges, next, curr, ret, times, minTimes, ref t);
                if (minTimes[next] > times[curr]) {
                    ret.Add(new List<int>() { curr, next });
                }
            }
            if (prev != next) {
                minTimes[curr] = Math.Min(minTimes[curr], minTimes[next]);
            }
        }
    }
    
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections) {
        var edges = new IList<int>[n];
        var ret = new List<IList<int>>();
        int t = 1;
        int[] times = new int[n], minTimes = new int[n];
        for (int i = 0; i < n; ++i) {
            edges[i] = new List<int>();
        }
        foreach (var connection in connections) {
            int a = connection[0], b = connection[1];
            edges[a].Add(b);
            edges[b].Add(a);
        }
        CriticalConnectionsRecurse(edges, 0, -1, ret, times, minTimes, ref t);
        return ret;
    }
}
// @lc code=end

