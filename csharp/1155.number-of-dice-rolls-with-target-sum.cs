/*
 * @lc app=leetcode id=1155 lang=csharp
 *
 * [1155] Number of Dice Rolls With Target Sum
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int NumRollsToTargetRecurse(int d, int f, int target, IDictionary<(int Count, int Target), int> memo) {
        if (target < d || target > f * d) {
            return 0;
        }
        var key = (Count: d, Target: target);
        if (memo.TryGetValue(key, out int ret)) {
            return ret;
        }
        ret = 0;
        for (int i = 1; i <= f; ++i) {
            ret = (ret + NumRollsToTargetRecurse(d - 1, f, target - i, memo)) % 1000000007;
        }
        memo[key] = ret;
        return ret;
    }

    public int NumRollsToTarget(int d, int f, int target) {
        var memo = new Dictionary<(int Count, int Target), int>();
        memo[(Count: 0, Target: 0)] = 1;
        return NumRollsToTargetRecurse(d, f, target, memo);
    }
}
// @lc code=end

