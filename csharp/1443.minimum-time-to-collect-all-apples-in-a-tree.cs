/*
 * @lc app=leetcode id=1443 lang=csharp
 *
 * [1443] Minimum Time to Collect All Apples in a Tree
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int? MinTime(IDictionary<int, HashSet<int>> map, int curr, IList<bool> hasApple) {
        int ret = 0;
        foreach (int child in map[curr]) {
            map[child].Remove(curr);
            var r = MinTime(map, child, hasApple);
            if (r.HasValue) {
                ret += 2 + r.Value;
            }
        }
        return (ret > 0 || hasApple[curr]) ? ret : default(int?);
    }

    public int MinTime(int n, int[][] edges, IList<bool> hasApple) {
        var map = new Dictionary<int, HashSet<int>>();
        foreach (var edge in edges) {
            int a = edge[0], b = edge[1];
            if (!map.TryGetValue(a, out var am)) {
                am = new HashSet<int>();
                map[a] = am;
            }
            if (!map.TryGetValue(b, out var bm)) {
                bm = new HashSet<int>();
                map[b] = bm;
            }
            am.Add(b);
            bm.Add(a);
        }
        var ret = MinTime(map, 0, hasApple);
        return ret.HasValue ? ret.Value : 0;
    }
}
// @lc code=end

