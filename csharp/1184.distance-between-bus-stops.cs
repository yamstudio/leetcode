/*
 * @lc app=leetcode id=1184 lang=csharp
 *
 * [1184] Distance Between Bus Stops
 */

using System;

// @lc code=start
public class Solution {
    public int DistanceBetweenBusStops(int[] distance, int start, int destination) {
        if (start > destination) {
            int t = destination;
            destination = start;
            start = t;
        }
        int n = distance.Length, a = 0, c = 0;
        for (int i = 0; i < n; ++i) {
            int d = distance[i];
            a += d;
            if (i >= start && i < destination) {
                c += d;
            }
        }
        return Math.Min(c, a - c);
    }
}
// @lc code=end

