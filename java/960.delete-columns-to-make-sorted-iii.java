/*
 * @lc app=leetcode id=960 lang=java
 *
 * [960] Delete Columns to Make Sorted III
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int minDeletionSize(String[] strs) {
        int n = strs.length, m = strs[0].length();
        int[] dp = new int[m];
        for (int i = 0; i < m; ++i) {
            dp[i] = 1;
        }
        for (int i = 1; i < m; ++i) {
            for (int j = 0; j < i; ++j) {
                int k;
                for (k = 0; k < n; ++k) {
                    String s = strs[k];
                    if (s.charAt(i) < s.charAt(j)) {
                        break;
                    }
                }
                if (k == n) {
                    dp[i] = Math.max(dp[i], 1 + dp[j]);
                }
            }
        }
        return m - Arrays.stream(dp).max().orElseThrow();
    }
}
// @lc code=end

