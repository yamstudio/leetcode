/*
 * @lc app=leetcode id=1579 lang=csharp
 *
 * [1579] Remove Max Number of Edges to Keep Graph Fully Traversable
 */

using System.Linq;

// @lc code=start
public class Solution {

    private static int FindRoot(int[] roots, int i) {
        return roots[i] == i ? i : (roots[i] = FindRoot(roots, roots[i]));
    }

    private static bool Union(int[] roots, int i, int j) {
        int ri = FindRoot(roots, i), rj = FindRoot(roots, j);
        if (ri == rj) {
            return false;
        }
        roots[ri] = rj;
        return true;
    }

    public int MaxNumEdgesToRemove(int n, int[][] edges) {
        var roots = Enumerable.Range(0, n + 1).ToArray();
        int ga = 0, gb = 0, ret = 0;
        foreach (var edge in edges) {
            if (edge[0] != 3) {
                continue;
            }
            if (!Union(roots, edge[1], edge[2])) {
                ++ret;
            } else {
                ++ga;
                ++gb;
            }
        }
        int[] ra = roots.ToArray(), rb = roots.ToArray();
        foreach (var edge in edges) {
            if (edge[0] != 1) {
                continue;
            }
            if (!Union(ra, edge[1], edge[2])) {
                ++ret;
            } else {
                ++ga;
            }
        }
        if (ga != n - 1) {
            return -1;
        }
        foreach (var edge in edges) {
            if (edge[0] != 2) {
                continue;
            }
            if (!Union(rb, edge[1], edge[2])) {
                ++ret;
            } else {
                ++gb;
            }
        }
        if (gb != n - 1) {
            return -1;
        }
        return ret;
    }
}
// @lc code=end

