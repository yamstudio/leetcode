/*
 * @lc app=leetcode id=947 lang=csharp
 *
 * [947] Most Stones Removed with Same Row or Column
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int FindRoot(int[] roots, int curr) {
        return roots[curr] == curr ? curr : FindRoot(roots, roots[curr]);
    }

    public int RemoveStones(int[][] stones) {
        int n = stones.Length;
        int[] roots = Enumerable.Range(0, n).ToArray();
        for (int i = 0; i < n; ++i) {
            for (int j = i + 1; j < n; ++j) {
                if (stones[i][0] == stones[j][0] || stones[i][1] == stones[j][1]) {
                    roots[FindRoot(roots, i)] = FindRoot(roots, j);
                }
            }
        }
        int ret = n;
        for (int i = 0; i < n; ++i) {
            if (i == roots[i]) {
                --ret;
            }
        }
        return ret;
    }
}
// @lc code=end

