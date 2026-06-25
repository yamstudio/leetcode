/*
 * @lc app=leetcode id=1774 lang=java
 *
 * [1774] Closest Dessert Cost
 */

import java.util.TreeSet;
import java.util.stream.Stream;

// @lc code=start
class Solution {
    public int closestCost(int[] baseCosts, int[] toppingCosts, int target) {
        TreeSet<Integer> tops = new TreeSet<>();
        tops.add(0);
        for (int t : toppingCosts) {
            tops.addAll(
                tops
                    .stream()
                    .flatMap(k -> Stream.of(k + t, k + t * 2))
                    .toList()
            );
        }
        int ret = 100_000;
        for (int b : baseCosts) {
            Integer k = tops.floor(target - b);
            if (k != null && target - (b + k) <= Math.abs(ret - target)) {
                ret = b + k;
            }
            k = tops.ceiling(target - b);
            if (k != null && (b + k) - target < Math.abs(ret - target)) {
                ret = b + k;
            }
        }
        return ret;
    }
}
// @lc code=end

