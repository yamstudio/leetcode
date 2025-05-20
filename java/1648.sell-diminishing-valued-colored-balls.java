/*
 * @lc app=leetcode id=1648 lang=java
 *
 * [1648] Sell Diminishing-Valued Colored Balls
 */

import java.util.Arrays;

// @lc code=start
import java.math.BigDecimal;

class Solution {
    public int maxProfit(int[] inventory, int orders) {
        Arrays.sort(inventory);
        int n = inventory.length, i = n - 1;
        BigDecimal ret = BigDecimal.ZERO;
        while (orders > 0 && i >= 0) {
            int curr = inventory[i];
            while (i >= 0 && inventory[i] == curr) {
                --i;
            }
            int next = i >= 0 ? inventory[i] : 0, count = n - 1 - i;
            BigDecimal all = BigDecimal.valueOf(count).multiply(BigDecimal.valueOf(curr - next));
            if (all.compareTo(BigDecimal.valueOf(orders)) <= 0) {
                ret = ret.add(BigDecimal.valueOf(curr + next + 1).multiply(BigDecimal.valueOf(curr - next)).divide(BigDecimal.TWO).multiply(BigDecimal.valueOf(count))).remainder(BigDecimal.valueOf(1000000007));
                orders -= all.intValue();
            } else {
                int full = orders / count, partial = orders % count;
                ret = ret.add(BigDecimal.valueOf(partial).multiply(BigDecimal.valueOf(curr - full)).add(BigDecimal.valueOf(curr + curr - full + 1).multiply(BigDecimal.valueOf(full).divide(BigDecimal.TWO).multiply(BigDecimal.valueOf(count))))).remainder(BigDecimal.valueOf(1000000007));
                break;
            }
        }
        return ret.intValue();
    }
}
// @lc code=end

