/*
 * @lc app=leetcode id=1599 lang=csharp
 *
 * [1599] Maximum Profit of Operating a Centennial Wheel
 */

using System;

// @lc code=start
public class Solution {
    public int MinOperationsMaxProfit(int[] customers, int boardingCost, int runningCost) {
        int n = customers.Length, i = 0, acc = 0, max = 0, ret = -1, r = 0, count = 0;
        while (i < n || count > 0) {
            if (i < n) {
                count += customers[i++];
            }
            int d = Math.Min(4, count);
            acc += boardingCost *d - runningCost;
            count -= d;
            ++r;
            if (acc > max) {
                max = acc;
                ret = r;
            }
        }
        return ret;
    }
}
// @lc code=end

