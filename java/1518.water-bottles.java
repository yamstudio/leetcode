/*
 * @lc app=leetcode id=1518 lang=java
 *
 * [1518] Water Bottles
 */

// @lc code=start
class Solution {
    public int numWaterBottles(int numBottles, int numExchange) {
        int ret = numBottles;
        while (numBottles >= numExchange) {
            ret += numBottles / numExchange;
            numBottles = numBottles / numExchange + numBottles % numExchange;
        }
        return ret;
    }
}
// @lc code=end

