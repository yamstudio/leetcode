/*
 * @lc app=leetcode id=1558 lang=java
 *
 * [1558] Minimum Numbers of Function Calls to Make Target Array
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int minOperations(int[] nums) {
        int adds = 0, muls = 0;
        Map<Integer, Pair> memo = new HashMap<>();
        for (int x : nums) {
            Pair p = minOperations(x, memo);
            adds += p.add();
            muls = Math.max(p.mul(), muls);
        }
        return adds + muls;
    }

    private static Pair minOperations(int x, Map<Integer, Pair> memo) {
        if (x <= 1) {
            return new Pair(0, x);
        }
        Pair ret = memo.get(x);
        if (ret != null) {
            return ret;
        }
        Pair half = minOperations(x / 2, memo);
        ret = new Pair(1 + half.mul(), x % 2 + half.add());
        memo.put(x, ret);
        return ret;
    }

    private record Pair(int mul, int add) {}
}
// @lc code=end

