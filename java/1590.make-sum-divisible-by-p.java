/*
 * @lc app=leetcode id=1590 lang=java
 *
 * [1590] Make Sum Divisible by P
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int minSubarray(int[] nums, int p) {
        int n = nums.length, acc = 0;
        for (int x : nums) {
            acc = (acc + x) % p;
        }
        int curr = 0, ret = n;
        Map<Integer, Integer> lastIndex = new HashMap<>();
        lastIndex.put(0, -1);
        for (int i = 0; i < n; ++i) {
            curr = (curr + nums[i]) % p;
            lastIndex.put(curr, i);
            Integer l = lastIndex.get((curr - acc + p) % p);
            if (l == null) {
                continue;
            }
            ret = Math.min(ret, i - l);
        }
        return ret == n ? -1 : ret;
    }
}
// @lc code=end

