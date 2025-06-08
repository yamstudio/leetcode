/*
 * @lc app=leetcode id=1665 lang=java
 *
 * [1665] Minimum Initial Energy to Finish Tasks
 */

import java.util.Arrays;

// @lc code=start
class Solution {
    public int minimumEffort(int[][] tasks) {
        int[][] sorted = Arrays.stream(tasks)
            .sorted(java.util.Comparator.comparing((int[] t) -> t[0] - t[1]))
            .toArray(int[][]::new);
        int ret = 0, acc = 0;
        for (int[] t : sorted) {
            if (acc < t[1]) {
                ret += t[1] - acc;
                acc = t[1];
            }
            acc -= t[0];
        }
        return ret;
    }
}
// @lc code=end

