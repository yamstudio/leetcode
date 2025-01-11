/*
 * @lc app=leetcode id=1218 lang=java
 *
 * [1218] Longest Arithmetic Subsequence of Given Difference
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int longestSubsequence(int[] arr, int difference) {
        Map<Integer, Integer> lastLength = new HashMap<>();
        int ret = 0;
        for (int n : arr) {
            int l = 1 + lastLength.getOrDefault(n - difference, 0);
            Integer existing = lastLength.get(n);
            if (existing == null || existing < l) {
                lastLength.put(n, l);
            }
            ret = Math.max(ret, l);
        }
        return ret;
    }
}
// @lc code=end

