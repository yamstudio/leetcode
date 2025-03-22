/*
 * @lc app=leetcode id=1482 lang=java
 *
 * [1482] Minimum Number of Days to Make m Bouquets
 */

import java.util.stream.IntStream;

// @lc code=start

class Solution {
    public int minDays(int[] bloomDay, int m, int k) {
        int n = bloomDay.length;
        if ((long)n < (long)m * (long)k) {
            return -1;
        }
        int[] days = IntStream.of(bloomDay).distinct().sorted().toArray();
        int l = 0, r = days.length - 1;
        while (l < r) {
            int mid = (l + r) / 2, d = days[mid], acc = 0, noBloom = -1;
            for (int i = 0; i < n && acc < m; ++i) {
                if (bloomDay[i] <= d) {
                    if (i - noBloom == k) {
                        ++acc;
                        noBloom = i;
                    }
                } else {
                    noBloom = i;
                }
            }
            if (m == acc) {
                r = mid;
            } else {
                l = mid + 1;
            }
        }
        return days[l];
    }
}
// @lc code=end

