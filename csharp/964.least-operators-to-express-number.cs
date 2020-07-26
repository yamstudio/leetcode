/*
 * @lc app=leetcode id=964 lang=csharp
 *
 * [964] Least Operators to Express Number
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int LeastOpsExpressTarget(int x, int target) {
        return LeastOpsExpressTargetRecurse(0, x, target, new Dictionary<(int N, int Target), int>()) - 1;
    }

    private static int LeastOpsExpressTargetRecurse(int n, int x, int target, IDictionary<(int N, int Target), int> memo) {
        var key = (N: n, Target: target);
        int ret = 0, b = n == 0 ? 2 : n;
        if (memo.TryGetValue(key, out ret)) {
            return ret;
        }
        if (target == 0) {
            return 0;
        }
        if (target == 1) {
            return b;
        }
        int q = target / x, r = target % x;
        ret = r * b + LeastOpsExpressTargetRecurse(n + 1, x, q, memo);
        if (r > 0) {
            ret = Math.Min(ret, (x - r) * b + LeastOpsExpressTargetRecurse(n + 1, x, q + 1, memo));
        }
        memo[key] = ret;
        return ret;
    }
}
// @lc code=end

