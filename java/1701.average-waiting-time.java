/*
 * @lc app=leetcode id=1701 lang=java
 *
 * [1701] Average Waiting Time
 */

// @lc code=start
class Solution {
    public double averageWaitingTime(int[][] customers) {
        int n = customers.length, t = customers[0][0];
        double total = 0;
        for (int i = 0; i < n; ++i) {
            var c = customers[i];
            if (t <= c[0]) {
                total += c[1];
                t = c[0] + c[1];
            } else {
                total += c[1] + t - c[0];
                t += c[1];
            }
        }
        return total / n;
    }
}
// @lc code=end

