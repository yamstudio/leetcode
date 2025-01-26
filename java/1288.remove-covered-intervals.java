/*
 * @lc app=leetcode id=1288 lang=java
 *
 * [1288] Remove Covered Intervals
 */

import java.util.List;
import java.util.Arrays;

// @lc code=start

import static java.util.Comparator.comparingInt;

class Solution {
    public int removeCoveredIntervals(int[][] intervals) {
        List<int[]> sorted = Arrays
            .stream(intervals)
            .sorted(comparingInt((int[] arr) -> arr[0]).thenComparingInt((int[] arr) -> -arr[1]))
            .toList();
        int n = intervals.length, ret = 0, l = 0;
        while (l < n) {
            int[] curr = sorted.get(l);
            int r = l + 1;
            while (r < n && sorted.get(r)[1] <= curr[1]) {
                ++r;
            }
            l = r;
            ++ret;
        }
        return ret;
    }
}
// @lc code=end

