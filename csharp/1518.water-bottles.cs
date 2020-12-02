/*
 * @lc app=leetcode id=1518 lang=csharp
 *
 * [1518] Water Bottles
 */

// @lc code=start
public class Solution {
    public int NumWaterBottles(int numBottles, int numExchange) {
        int ret = numBottles;
        while (numBottles >= numExchange) {
            int d = numBottles / numExchange;
            ret += d;
            numBottles = numBottles - d * numExchange + d;
        }
        return ret;
    }
}
// @lc code=end

