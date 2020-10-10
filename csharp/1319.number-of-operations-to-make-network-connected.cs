/*
 * @lc app=leetcode id=1319 lang=csharp
 *
 * [1319] Number of Operations to Make Network Connected
 */

using System.Linq;

// @lc code=start
public class Solution {

    private static int FindRoot(int[] roots, int i) {
        return roots[i] == i ? i : (roots[i] = FindRoot(roots, roots[i]));
    }

    public int MakeConnected(int n, int[][] connections) {
        if (connections.Length < n - 1) {
            return -1;
        }
        int[] roots = Enumerable.Range(0, n).ToArray();
        foreach (int[] connection in connections) {
            int a = connection[0], b = connection[1], r = FindRoot(roots, b);
            roots[FindRoot(roots, a)] = r;
        }
        return roots.Select(i => FindRoot(roots, i)).Distinct().Count() - 1;
    }
}
// @lc code=end

