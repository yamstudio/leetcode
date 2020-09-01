/*
 * @lc app=leetcode id=1109 lang=csharp
 *
 * [1109] Corporate Flight Bookings
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int[] CorpFlightBookings(int[][] bookings, int n) {
        int[] ret = new int[n];
        int acc = 0;
        var points = new Dictionary<int, int>();
        foreach (var booking in bookings) {
            int start = booking[0], end = booking[1], num = booking[2];
            if (points.TryGetValue(start, out int s)) {
                points[start] = s + num;
            } else {
                points[start] = num;
            }
            if (points.TryGetValue(end + 1, out int e)) {
                points[end + 1] = e - num;
            } else {
                points[end + 1] = -num;
            }
        }
        for (int i = 0; i < n; ++i) {
            if (points.TryGetValue(i + 1, out int d)) {
                acc += d;
            }
            ret[i] = acc;
        }
        return ret;
    }
}
// @lc code=end

