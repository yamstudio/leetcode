/*
 * @lc app=leetcode id=1648 lang=csharp
 *
 * [1648] Sell Diminishing-Valued Colored Balls
 */

using System;

// @lc code=start
public class Solution {
    public int MaxProfit(int[] inventory, int orders) {
        long ret = 0;
        int n = inventory.Length;;
        Array.Sort(inventory);
        Array.Reverse(inventory);
        for (int i = 0; i < n; ++i) {
            if (i < n - 1 && inventory[i] == inventory[i + 1]) {
                continue;
            }
            int curr = inventory[i], next = i == n - 1 ? 0 : inventory[i + 1], total = (i + 1) * (curr - next);
            if (total <= orders) {
                orders -= total;
                ret = (ret + (long)total * (long)(curr + next + 1) / 2) % 1000000007;
            } else {
                int full = orders / (i + 1), rem = orders % (i + 1);
                ret = (ret + (long)(i + 1) * (long)full * (long)(curr + curr - full + 1) / 2) % 1000000007;
                ret = (ret + (long)rem * (long)(curr - full)) % 1000000007;
                break;
            }
        }
        return (int)ret;
    }
}
// @lc code=end

