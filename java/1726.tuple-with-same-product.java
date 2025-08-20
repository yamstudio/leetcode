/*
 * @lc app=leetcode id=1726 lang=java
 *
 * [1726] Tuple with Same Product
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int tupleSameProduct(int[] nums) {
        int ret = 0, n = nums.length;
        Map<Integer, Integer> count = new HashMap<>();
        for (int i = 0; i < n; ++i) {
            int x = nums[i];
            for (int j = i + 1; j < n; ++j) {
                int p = x * nums[j];
                count.put(p, count.getOrDefault(p, 0) + 1);
            }
        }
        for (int v : count.values()) {
            ret += 4 * v * (v - 1);
        }
        return ret;
    }
}
// @lc code=end

