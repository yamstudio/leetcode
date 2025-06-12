/*
 * @lc app=leetcode id=1679 lang=java
 *
 * [1679] Max Number of K-Sum Pairs
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int maxOperations(int[] nums, int k) {
        Map<Long, Integer> count = new HashMap<>();
        int ret = 0;
        for (long x : nums) {
            long y = (long)k - x;
            int c = count.getOrDefault(y, 0);
            if (c > 0) {
                count.put(y, c - 1);
                ++ret;
            } else {
                count.put(x, count.getOrDefault(x, 0) + 1);
            }
        }
        return ret;
    }
}
// @lc code=end

