/*
 * @lc app=leetcode id=1227 lang=java
 *
 * [1227] Airplane Seat Assignment Probability
 */

// @lc code=start
class Solution {
    public double nthPersonGetsNthSeat(int n) {
        if (n == 1) {
            return 1.0;
        }
        return 1 / (double)n + (double)(n - 2) / (double)n * nthPersonGetsNthSeat(n - 1);
    }
}
// @lc code=end

