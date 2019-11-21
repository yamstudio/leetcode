/*
 * @lc app=leetcode id=684 lang=csharp
 *
 * [684] Redundant Connection
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int Find(IDictionary<int, int> map, int x) {
        while (map.ContainsKey(x)) {
            x = map[x];
        }
        return x;
    }

    public int[] FindRedundantConnection(int[][] edges) {
        IDictionary<int, int> map = new Dictionary<int, int>();
        foreach (var edge in edges) {
            int rx = Find(map, edge[0]), ry = Find(map, edge[1]);
            if (rx == ry) {
                return edge;
            }
            map[rx] = ry;
        }
        return null;
    }
}
// @lc code=end

