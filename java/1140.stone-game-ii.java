/*
 * @lc app=leetcode id=1140 lang=java
 *
 * [1140] Stone Game II
 */

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

// @lc code=start
class Solution {
    public int stoneGameII(int[] piles) {
        int maxDiff = helper(piles, 0, 1, new HashMap<>());
        return (Arrays.stream(piles).sum() + maxDiff) / 2;
    }

    private static int helper(int[] piles, int start, int max, Map<String, Integer> memo) {
        int n = piles.length;
        if (start >= n) {
            return 0;
        }
        String key = "%d,%d".formatted(start, max);
        Integer cached = memo.get(key);
        if (cached != null) {
            return cached;
        }
        int ret = Integer.MIN_VALUE, acc = 0;
        for (int i = 1; i <= 2 * max && start + i <= n; ++i) {
            acc += piles[start + i - 1];
            ret = Math.max(ret, acc - helper(piles, start + i, Math.max(max, i), memo));
        }
        memo.put(key, ret);
        return ret;
    }
}
// @lc code=end

