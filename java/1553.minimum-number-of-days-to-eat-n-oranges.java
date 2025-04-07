/*
 * @lc app=leetcode id=1553 lang=java
 *
 * [1553] Minimum Number of Days to Eat N Oranges
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int minDays(int n) {
        return minDays(n, new HashMap<>());
    }

    private static int minDays(int n, Map<Integer, Integer> memo) {
        if (n <= 2) {
            return n;
        }
        Integer m = memo.get(n);
        if (m != null) {
            return m;
        }
        int days = 1 + Math.min(n % 2 + minDays(n / 2, memo), n % 3 + minDays(n / 3, memo));
        memo.put(n, days);
        return days;
    }
}
// @lc code=end

