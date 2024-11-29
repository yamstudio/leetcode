/*
 * @lc app=leetcode id=964 lang=java
 *
 * [964] Least Operators to Express Number
 */

import java.util.Map;
import java.util.HashMap;

// @lc code=start
class Solution {
    public int leastOpsExpressTarget(int x, int target) {
        return leastOpsExpressTarget(x, target, 0, new HashMap<>()) - 1;
    }

    private static int leastOpsExpressTarget(int x, int target, int mult, Map<MemoKey, Integer> memo) {
        if (target == 0) {
            return 0;
        }
        var key = new MemoKey(mult, target);
        Integer maybeValue = memo.get(key);
        if (maybeValue != null) {
            return maybeValue;
        }
        int multFactor = mult == 0 ? 2 : mult;
        if (target == 1) {
            return multFactor;
        }
        int q = target / x, r = target % x;
        int ret = r * multFactor + leastOpsExpressTarget(x, q, mult + 1, memo);
        if (r > 0) {
            ret = Math.min(ret, (x - r) * multFactor + leastOpsExpressTarget(x, q + 1, mult + 1, memo));
        }
        memo.put(key, ret);
        return ret;
    }

    private record MemoKey(int mult, int target) {}
}
// @lc code=end

