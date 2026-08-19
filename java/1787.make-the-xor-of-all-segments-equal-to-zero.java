/*
 * @lc app=leetcode id=1787 lang=java
 *
 * [1787] Make the XOR of All Segments Equal to Zero
 */

import java.util.Map;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

// @lc code=start
class Solution {
    public int minChanges(int[] nums, int k) {
        List<Map<Integer, Integer>> posCount = new ArrayList<>(k);
        int n = nums.length;
        for (int i = 0; i < n; ++i) {
            if (i < k) {
                posCount.add(new HashMap<>());
            }
            int val = nums[i];
            var count = posCount.get(i % k);
            count.put(val, count.getOrDefault(val, 0) + 1);
        }
        int[][] dp = new int[2][1024];
        for (int i = 1; i < 1024; ++i) {
            dp[0][i] = -n;
        }
        for (int i = 0; i < k; ++i) {
            int max = 0;
            for (int j = 0; j < 1024; ++j) {
                max = Math.max(max, dp[i % 2][j]);
            }
            for (int j = 0; j < 1024; ++j) {
                dp[1 - i % 2][j] = max;
            }
            var count = posCount.get(i);
            for (var entry : count.entrySet()) {
                int val = entry.getKey(), freq = entry.getValue();
                for (int j = 0; j < 1024; ++j) {
                    dp[1 - i % 2][val ^ j] = Math.max(
                        dp[1 - i % 2][val ^ j],
                        freq + dp[i % 2][j]
                    );
                }
            }
        }
        return n - dp[k % 2][0];
    }
}
// @lc code=end

