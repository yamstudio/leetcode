/*
 * @lc app=leetcode id=1690 lang=csharp
 *
 * [1690] Stone Game VII
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {

    private static int StoneGameVII(int[] stones, int l, int r, int sum, int?[,] memo) {
        if (l == r) {
            return 0;
        }
        if (memo[l, r].HasValue) {
            return memo[l, r].Value;
        }
        int ret = Math.Max(
            sum - stones[l] - StoneGameVII(stones, l + 1, r, sum - stones[l], memo),
            sum - stones[r] - StoneGameVII(stones, l, r - 1, sum - stones[r], memo)
        );
        memo[l, r] = ret;
        return ret;
    }

    public int StoneGameVII(int[] stones) {
        int n = stones.Length;
        return StoneGameVII(stones, 0, n - 1, stones.Sum(), new int?[n, n]);
    }
}
// @lc code=end

