/*
 * @lc app=leetcode id=1253 lang=csharp
 *
 * [1253] Reconstruct a 2-Row Binary Matrix
 */

using System.Linq;

// @lc code=start
public class Solution {
    public IList<IList<int>> ReconstructMatrix(int upper, int lower, int[] colsum) {
        int n = colsum.Length;
        IList<int> u = Enumerable.Repeat(0, n).ToList(), l = Enumerable.Repeat(0, n).ToList();
        for (int i = 0; i < n; ++i) {
            int sum = colsum[i];
            if (sum != 2) {
                continue;
            }
            if (sum == 2) {
                u[i] = 1;
                l[i] = 1;
                --upper;
                --lower;
                continue;
            }
        }
        if (upper < 0 || lower < 0) {
            return new List<IList<int>>();
        }
        for (int i = 0; i < n; ++i) {
            int sum = colsum[i];
            if (sum != 1) {
                continue;
            }
            if (upper > 0) {
                --upper;
                u[i] = 1;
            } else {
                --lower;
                l[i] = 1;
            }
        }
        
        if (upper != 0 || lower != 0) {
            return new List<IList<int>>();
        }
        return new List<IList<int>>() { u, l };
    }
}
// @lc code=end

