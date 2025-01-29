/*
 * @lc app=leetcode id=1296 lang=java
 *
 * [1296] Divide Array in Sets of K Consecutive Numbers
 */

import java.util.HashMap;
import java.util.List;
import java.util.Map;

// @lc code=start

class Solution {
    public boolean isPossibleDivide(int[] nums, int k) {
        Map<Integer, Integer> count = new HashMap<>();
        for (int num : nums) {
            count.put(num, 1 + count.getOrDefault(num, 0));
        }
        List<Integer> sorted = count.keySet().stream().sorted().toList();
        for (int num : sorted) {
            Integer e = count.get(num);
            if (e == 0) {
                continue;
            }
            for (int i = 0; i < k; ++i) {
                int c = num + i;
                Integer p = count.get(c);
                if (p == null || p < e) {
                    return false;
                }
                count.put(c, p - e);
            }
        }
        return true;
    }
}
// @lc code=end

