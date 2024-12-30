/*
 * @lc app=leetcode id=1155 lang=java
 *
 * [1155] Number of Dice Rolls With Target Sum
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    
    public int numRollsToTarget(int n, int k, int target) {
        Map<String, Integer> memo = new HashMap<>();
        memo.put("0,0", 1);
        return helper(n, k, target, memo);
    }

    private static int helper(int count, int k, int target, Map<String, Integer> memo) {
        String key = "%d,%d".formatted(count, target);
        Integer cached = memo.get(key);
        if (cached != null) {
            return cached;
        }
        if (target < 0 || target > count * k) {
            return 0;
        }
        int ret = 0;
        for (int i = 1; i <= k; ++i) {
            ret = (ret + helper(count - 1, k, target - i, memo)) % 1000000007;
        }
        memo.put(key, ret);
        return ret;
    }
}
// @lc code=end

