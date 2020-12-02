/*
 * @lc app=leetcode id=1519 lang=csharp
 *
 * [1519] Number of Nodes in the Sub-Tree With the Same Label
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    private static int[] CountSubTrees(int curr, int[] ret, HashSet<int>[] map, string labels) {
        int[] total = new int[26];
        if (map[curr] != null) {
            foreach (int next in map[curr]) {
                map[next].Remove(curr);
                var t = CountSubTrees(next, ret, map, labels);
                for (int i = 0; i < 26; ++i) {
                    total[i] += t[i];
                }
            }
        }
        ret[curr] = ++total[(int)labels[curr] - (int)'a'];
        return total;
    }

    public int[] CountSubTrees(int n, int[][] edges, string labels) {
        var map = new HashSet<int>[n];
        var ret = new int[n];
        foreach (var edge in edges) {
            int a = edge[0], b = edge[1];
            if (map[a] == null) {
                map[a] = new HashSet<int>();
            }
            if (map[b] == null) {
                map[b] = new HashSet<int>();
            }
            map[a].Add(b);
            map[b].Add(a);
        }
        CountSubTrees(0, ret, map, labels);
        return ret;
    }
}
// @lc code=end

