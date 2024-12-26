/*
 * @lc app=leetcode id=1109 lang=java
 *
 * [1109] Corporate Flight Bookings
 */

// @lc code=start

class Solution {
    public int[] corpFlightBookings(int[][] bookings, int n) {
        int[] ret = new int[n];
        for (int[] booking : bookings) {
            ret[booking[0] - 1] += booking[2];
            if (booking[1] < n) {
                ret[booking[1]] -= booking[2];
            }
        }
        for (int i = 1; i < n; ++i) {
            ret[i] += ret[i - 1];
        }
        return ret;
    }
}
// @lc code=end

