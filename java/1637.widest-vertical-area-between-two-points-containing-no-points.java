/*
 * @lc app=leetcode id=1637 lang=java
 *
 * [1637] Widest Vertical Area Between Two Points Containing No Points
 */

// @lc code=start

import java.util.Arrays;

class Solution {
    public int maxWidthOfVerticalArea(int[][] points) {
        int[] sorted = Arrays.stream(points).mapToInt(p -> p[0]).distinct().sorted().toArray();
        int ret = 0, n = sorted.length;
        for (int i = 1; i < n; ++i) {
            ret = Math.max(sorted[i] - sorted[i - 1], ret);
        }
        return ret;
    }
}
// @lc code=end

