/*
 * @lc app=leetcode id=1488 lang=java
 *
 * [1488] Avoid Flood in The City
 */

import java.util.HashMap;
import java.util.Map;
import java.util.TreeSet;

// @lc code=start

class Solution {
    public int[] avoidFlood(int[] rains) {
        int n = rains.length;
        int[] ret = new int[n];
        var drys = new TreeSet<Integer>();
        Map<Integer, Integer> fullToIndex = new HashMap<>();
        for (int i = 0; i < n; ++i) {
            int lake = rains[i];
            if (lake == 0) {
                ret[i] = 69;
                drys.add(i);
                continue;
            }
            ret[i] = -1;
            Integer j = fullToIndex.put(lake, i);
            if (j == null) {
                continue;
            }
            Integer d = drys.ceiling(j + 1);
            if (d == null) {
                return new int[0];
            }
            drys.remove(d);
            ret[d] = lake;
        }
        return ret;
    }
}
// @lc code=end

