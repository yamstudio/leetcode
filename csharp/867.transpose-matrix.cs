/*
 * @lc app=leetcode id=867 lang=csharp
 *
 * [867] Transpose Matrix
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int[][] Transpose(int[][] A) {
        int m = A.Length, n = A[0].Length;
        return Enumerable
            .Range(0, n)
            .Select(j => Enumerable
                .Range(0, m)
                .Select(i => A[i][j])
                .ToArray())
            .ToArray();
    }
}
// @lc code=end

