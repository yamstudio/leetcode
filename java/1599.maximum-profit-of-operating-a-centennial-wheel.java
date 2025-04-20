/*
 * @lc app=leetcode id=1599 lang=java
 *
 * [1599] Maximum Profit of Operating a Centennial Wheel
 */

// @lc code=start
class Solution {
    public int minOperationsMaxProfit(int[] customers, int boardingCost, int runningCost) {
        int wait = 0, n = customers.length, acc = 0, ret = 0, max = 0, r;
        for (r = 0; r < n || wait > 0; ++r) {
            if (r < n) {
                wait += customers[r];
            }
            int take = Math.min(4, wait);
            wait -= take;
            acc += take * boardingCost - runningCost;
            if (acc > max) {
                max = acc;
                ret = r + 1;
            }
        }
        return ret == 0 ? -1 : ret;
    }
}
// @lc code=end

