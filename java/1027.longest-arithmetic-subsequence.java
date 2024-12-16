/*
 * @lc app=leetcode id=1027 lang=java
 *
 * [1027] Longest Arithmetic Subsequence
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int longestArithSeqLength(int[] nums) {
        int ret = 0, n = nums.length;
        Map<Key, Integer> count = new HashMap<>();
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < i; ++j) {
                int step = nums[i] - nums[j], val = count.getOrDefault(new Key(j, step), 1) + 1;
                ret = Math.max(ret, val);
                count.put(new Key(i, step), val);
            }
        }
        return ret;
    }

    private record Key(int index, int step) {}
}
// @lc code=end

