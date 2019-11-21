/*
 * @lc app=leetcode id=685 lang=csharp
 *
 * [685] Redundant Connection II
 */

// @lc code=start
public class Solution {
    
    private static int Find(int[] map, int x) {
        while (map[x] != x) {
            x = map[x];
        }
        return x;
    }

    public int[] FindRedundantDirectedConnection(int[][] edges) {
        int n = edges.Length;
        int[] map = new int[n + 1], first = null, second = null, cycle = null;
        foreach (int[] edge in edges) {
            int u = edge[0], v = edge[1];
            if (map[v] != 0) {
                first = new int[] { map[v], v };
                second = edge;
                break;
            }
            map[v] = u;
        }
        for (int i = 0; i <= n; ++i) {
            map[i] = i;
        }
        foreach (int[] edge in edges) {
            int u = edge[0], v = edge[1];
            if (first != null && u == second[0] && v == second[1]) {
                continue;
            }
            int ru = Find(map, u), rv = Find(map, v);
            if (ru == rv) {
                cycle = edge;
            }
            map[ru] = rv;
        }
        return first != null ? (cycle == null ? second : first) : cycle;
    }
}
// @lc code=end

