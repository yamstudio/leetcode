/*
 * @lc app=leetcode id=1727 lang=java
 *
 * [1727] Largest Submatrix With Rearrangements
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int largestSubmatrix(int[][] matrix) {
        int n = matrix[0].length, ret = 0;
        int[] h = new int[n], hc = new int[n];
        for (int[] r : matrix) {
            for (int i = 0; i < n; ++i) {
                if (r[i] == 0) {
                    h[i] = 0;
                } else {
                    h[i]++;
                }
                hc[i] = h[i];
            }
            Arrays.sort(hc);
            for (int i = 0; i < n; ++i) {
                ret = Math.max(ret, hc[i] * (n - i));
            }
        }
        return ret;
    }
}
// @lc code=end

