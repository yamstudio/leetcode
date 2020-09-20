/*
 * @lc app=leetcode id=1227 lang=csharp
 *
 * [1227] Airplane Seat Assignment Probability
 */

// @lc code=start
public class Solution {
    public double NthPersonGetsNthSeat(int n) {
        return n == 1 ? 1 : 0.5;
    }
}
// @lc code=end

