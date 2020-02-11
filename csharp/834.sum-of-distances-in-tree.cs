/*
 * @lc app=leetcode id=834 lang=csharp
 *
 * [834] Sum of Distances in Tree
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static void BuildRet(IList<int>[] map, int[] count, int[] ret, int N, int prev, int curr) {
        foreach (var next in map[curr]) {
            if (next == prev) {
                continue;
            }
            ret[next] = N - 2 * count[next] + ret[curr];
            BuildRet(map, count, ret, N, curr, next);
        }
    }

    private static void BuildCount(IList<int>[] map, int[] count, int[] ret, int prev, int curr) {
        count[curr] = 1;
        foreach (var next in map[curr]) {
            if (next == prev) {
                continue;
            }
            BuildCount(map, count, ret, curr, next);
            count[curr] += count[next];
            ret[curr] += count[next] + ret[next];
        }
    }

    public int[] SumOfDistancesInTree(int N, int[][] edges) {
        var map = new IList<int>[N];
        var count = new int[N];
        var ret = new int[N];
        for (int i = 0; i < N; ++i) {
            map[i] = new List<int>();
        }
        foreach (var edge in edges) {
            int x = edge[0], y = edge[1];
            map[x].Add(y);
            map[y].Add(x);
        }
        BuildCount(map, count, ret, -1, 0);
        BuildRet(map, count, ret, N, -1, 0);
        return ret;
    }
}
// @lc code=end

