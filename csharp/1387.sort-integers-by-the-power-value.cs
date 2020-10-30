/*
 * @lc app=leetcode id=1387 lang=csharp
 *
 * [1387] Sort Integers by The Power Value
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int GetPower(int x, IDictionary<int, int> memo) {
        if (memo.TryGetValue(x, out var v)) {
            return v;
        }
        if (x % 2 == 0) {
            v = 1 + GetPower(x / 2, memo);
        } else {
            v = 1 + GetPower(1 + 3 * x, memo);
        }
        memo[x] = v;
        return v;
    }

    public int GetKth(int lo, int hi, int k) {
        var memo = new Dictionary<int, int>() {
            { 1, 0 }
        };
        for (int i = lo; i <= hi; ++i) {
            GetPower(i, memo);
        }
        return Enumerable
            .Range(lo, hi - lo + 1)
            .Select(i => (Value: i, Power: memo[i]))
            .OrderBy(t => t.Power)
            .ThenBy(t => t.Value)
            .Skip(k - 1)
            .First().Value;
    }
}
// @lc code=end

