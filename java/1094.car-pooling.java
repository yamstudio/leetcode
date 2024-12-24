/*
 * @lc app=leetcode id=1094 lang=java
 *
 * [1094] Car Pooling
 */

import java.util.Arrays;
import java.util.stream.Stream;

// @lc code=start

import static java.util.Comparator.comparing;

class Solution {
    public boolean carPooling(int[][] trips, int capacity) {
        int count = 0;
        Pair[] diffs = Arrays.stream(trips).flatMap(trip -> Stream.of(new Pair(trip[2], -trip[0]), new Pair(trip[1], trip[0]))).sorted(comparing(Pair::time).thenComparing(Pair::count)).toArray(Pair[]::new);
        for (Pair curr : diffs) {
            count += curr.count();
            if (count > capacity) {
                return false;
            }
        }
        return true;
    }

    private record Pair(int time, int count) {};
}
// @lc code=end

