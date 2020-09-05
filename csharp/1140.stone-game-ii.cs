/*
 * @lc app=leetcode id=1140 lang=csharp
 *
 * [1140] Stone Game II
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int GetDiff(int[] piles, int n, int start, int max, IDictionary<(int Start, int Max), int> memo) {
        if (start >= n) {
            return 0;
        }
        var key = (Start: start, Max: max);
        if (memo.TryGetValue(key, out int ret)) {
            return ret;
        }
        ret = int.MinValue;
        int curr = 0;
        for (int i = 1; i <= 2 * max && start + i <= n; ++i) {
            curr += piles[start + i - 1];
            ret = Math.Max(ret, curr - GetDiff(piles, n, start + i, Math.Max(max, i), memo));
        }
        memo[key] = ret;
        return ret;
    }

    public int StoneGameII(int[] piles) {
        int diff = GetDiff(piles, piles.Length, 0, 1, new Dictionary<(int Start, int Max), int>());
        return (piles.Sum() + diff) / 2;
    }
}
// @lc code=end

