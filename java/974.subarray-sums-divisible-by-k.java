/*
 * @lc app=leetcode id=974 lang=java
 *
 * [974] Subarray Sums Divisible by K
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int subarraysDivByK(int[] nums, int k) {
        Map<Integer, Integer> count = new HashMap<>();
        int sum = 0, ret = 0;
        count.put(0, 1);
        for (int num : nums) {
            sum = (k + (sum + num) % k) % k;
            int c = count.getOrDefault(sum, 0);
            ret += c;
            count.put(sum, c + 1);
        }
        return ret;
    }
}
// @lc code=end

