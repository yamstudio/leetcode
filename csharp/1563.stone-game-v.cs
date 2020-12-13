/*
 * @lc app=leetcode id=1563 lang=csharp
 *
 * [1563] Stone Game V
 */

using System;

// @lc code=start
public class Solution {

    private static int GetScore(int[] sums, int i, int j, int?[,] memo) {
        if (i == j) {
            return 0;
        }
        if (memo[i, j].HasValue) {
            return memo[i, j].Value;
        }
        int ret = 0;
        for (int k = i; k < j; ++k) {
            int l = sums[k + 1] - sums[i], r = sums[j + 1] - sums[k + 1];
            if (l < r) {
                ret = Math.Max(ret, l + GetScore(sums, i, k, memo));
            } else if (l > r) {
                ret = Math.Max(ret, r + GetScore(sums, k + 1, j, memo));
            } else {
                ret = Math.Max(ret, l + Math.Max(GetScore(sums, i, k, memo), GetScore(sums, k + 1, j, memo)));
            }
        }
        memo[i, j] = ret;
        return ret;
    }

    public int StoneGameV(int[] stoneValue) {
        int n = stoneValue.Length;
        int[] sums = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            sums[i + 1] = sums[i] + stoneValue[i];
        }
        return GetScore(sums, 0, n - 1, new int?[n, n]);
    }
}
// @lc code=end

