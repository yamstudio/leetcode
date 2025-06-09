/*
 * @lc app=leetcode id=1672 lang=java
 *
 * [1672] Richest Customer Wealth
 */

import java.util.Arrays;
import java.util.stream.IntStream;

// @lc code=start

class Solution {
    public int maximumWealth(int[][] accounts) {
        return Arrays.stream(accounts)
            .map(Arrays::stream)
            .map(IntStream::sum)
            .max(java.util.Comparator.naturalOrder())
            .orElseThrow();
    }
}
// @lc code=end

