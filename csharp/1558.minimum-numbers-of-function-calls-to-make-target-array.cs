/*
 * @lc app=leetcode id=1558 lang=csharp
 *
 * [1558] Minimum Numbers of Function Calls to Make Target Array
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static (int A, int M) MinOperations(int x, IDictionary<int, (int A, int M)> memo) {
        if (x <= 1) {
            return (A: x, M: 0);
        }
        if (memo.TryGetValue(x, out var t)) {
            return t;
        }
        var p = MinOperations(x / 2, memo);
        return memo[x] = (A: p.A + x % 2, M: p.M + 1);
    }

    public int MinOperations(int[] nums) {
        int mt = 0, ret = 0;
        var memo = new Dictionary<int, (int A, int M)>();
        foreach (int x in nums) {
            var t = MinOperations(x, memo);
            ret += t.A;
            mt = Math.Max(mt, t.M);
        }
        return mt + ret;
    }
}
// @lc code=end

