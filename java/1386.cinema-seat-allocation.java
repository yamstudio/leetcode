/*
 * @lc app=leetcode id=1386 lang=java
 *
 * [1386] Cinema Seat Allocation
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start
class Solution {
    public int maxNumberOfFamilies(int n, int[][] reservedSeats) {
        Map<Integer, Integer> rows = new HashMap<>();
        for (int[] ss : reservedSeats) {
            rows.put(ss[0] - 1, rows.getOrDefault(ss[0] - 1, 0) | (1 << (ss[1] - 1)));
        }
        int ret = 2 * (n - rows.size());
        for (int row : rows.values()) {
            if ((row & 0b11110) == 0) {
                ++ret;
                if ((row & 0b111100000) == 0) {
                    ++ret;
                }
            } else if ((row & 0b1111000) == 0) {
                ++ret;
            } else if ((row & 0b111100000) == 0) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

