/*
 * @lc app=leetcode id=903 lang=csharp
 *
 * [903] Valid Permutations for DI Sequence
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int Sum(int a, int b) {
        return (a + b) % 1000000007;
    }

    public int NumPermsDISequence(string S) {
        int n = S.Length;
        int[,] dp = new int[n + 1, n + 1];
        dp[0, 0] = 1;
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j <= i; ++j) {
                IEnumerable<int> indices;
                if (S[i - 1] == 'D') {
                    indices = Enumerable.Range(j, i - j);
                } else {
                    indices = Enumerable.Range(0, j);
                }
                dp[i, j] = indices
                    .Select(k => dp[i - 1, k])
                    .DefaultIfEmpty()
                    .Aggregate(Sum);
            }
        }
        return Enumerable
            .Range(0, n + 1)
            .Select(k => dp[n, k])
            .Aggregate(Sum);
    }
}
// @lc code=end

