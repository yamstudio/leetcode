/*
 * @lc app=leetcode id=1504 lang=csharp
 *
 * [1504] Count Submatrices With All Ones
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int NumSubmat(int[][] mat) {
        int m = mat.Length, n = mat[0].Length, ret = 0;
        int[] up = new int[n];
        var stack = new Stack<int>();
        for (int i = 0; i < m; ++i) {
            int[] sums = new int[n];
            for (int j = 0; j < n; ++j) {
                if (mat[i][j] == 0) {
                    up[j] = 0;
                    stack.Clear();
                    stack.Push(j);
                    continue;
                }
                ++up[j];
                while (stack.TryPeek(out int k) && up[k] >= up[j]) {
                    stack.Pop();
                }
                if (stack.TryPeek(out int p)) {
                    sums[j] = sums[p] + up[j] * (j - p);
                } else {
                    sums[j] = up[j] * (j + 1);
                }
                stack.Push(j);
            }
            ret += sums.Sum();
            stack.Clear();
        }
        return ret;
    }
}
// @lc code=end

