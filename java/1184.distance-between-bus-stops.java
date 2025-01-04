/*
 * @lc app=leetcode id=1184 lang=java
 *
 * [1184] Distance Between Bus Stops
 */

// @lc code=start
class Solution {
    public int distanceBetweenBusStops(int[] distance, int start, int destination) {
        int min = Math.min(start, destination), max = start + destination - min, l = 0, r = 0, n = distance.length;
        for (int i = 0; i < n; ++i) {
            if (i < min || i >= max) {
                r += distance[i];
            } else {
                l += distance[i];
            }
        }
        return Math.min(l, r);
    }
}
// @lc code=end

