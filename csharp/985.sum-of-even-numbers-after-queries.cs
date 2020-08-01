/*
 * @lc app=leetcode id=985 lang=csharp
 *
 * [985] Sum of Even Numbers After Queries
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int[] SumEvenAfterQueries(int[] A, int[][] queries) {
        int n = queries.Length, b = A.Where(x => x % 2 == 0).Sum();
        var ret = new int[n];
        for (int i = 0; i < n; ++i) {
            int d = queries[i][0], j = queries[i][1], v = A[j];
            if (v % 2 == 0) {
                if (d % 2 == 0) {
                    b += d;
                } else {
                    b -= v;
                }
            } else {
                if (d % 2 != 0) {
                    b += d + v;
                }
            }
            ret[i] = b;
            A[j] = d + v;
        }
        return ret;
    }
}
// @lc code=end

