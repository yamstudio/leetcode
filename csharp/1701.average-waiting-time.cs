/*
 * @lc app=leetcode id=1701 lang=csharp
 *
 * [1701] Average Waiting Time
 */

// @lc code=start
public class Solution {
    public double AverageWaitingTime(int[][] customers) {
        int t = 0;
        double total = 0;
        foreach (var c in customers) {
            int a = c[0], d = c[1];
            if (t <= a) {
                total += d;
                t = a + d;
            } else {
                total += t - a + d;
                t += d;
            }
        }
        return total / customers.Length;
    }
}
// @lc code=end

