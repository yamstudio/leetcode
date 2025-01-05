/*
 * @lc app=leetcode id=1187 lang=java
 *
 * [1187] Make Array Strictly Increasing
 */

import java.util.Arrays;

// @lc code=start
class Solution {
    public int makeArrayIncreasing(int[] arr1, int[] arr2) {
        int m = arr1.length;
        int[] sorted = Arrays.stream(arr2).distinct().sorted().toArray();
        int n = sorted.length;
        int noSwapMoves = 0;
        int[] swapMoves = new int[n];
        for (int i = 0; i < n; ++i) {
            swapMoves[i] = 1;
        }
        for (int i = 1; i < m; ++i) {
            int nextNoSwapMoves = arr1[i] > arr1[i - 1] ? noSwapMoves : 10000000;
            int[] nextSwapMoves = new int[n];
            for (int j = 0; j < n; ++j) {
                nextSwapMoves[j] = 10000000;
                if (arr1[i] > sorted[j]) {
                    nextNoSwapMoves = Math.min(nextNoSwapMoves, swapMoves[j]);
                }
                if (sorted[j] > arr1[i - 1]) {
                    nextSwapMoves[j] = Math.min(nextSwapMoves[j], 1 + noSwapMoves);
                }
                if (j > 0) {
                    nextSwapMoves[j] = Math.min(nextSwapMoves[j], 1 + swapMoves[j - 1]);
                }
            }
            swapMoves = nextSwapMoves;
            noSwapMoves = nextNoSwapMoves;
        }
        int ret = noSwapMoves;
        for (int i = 0; i < n; ++i) {
            ret = Math.min(ret, swapMoves[i]);
        }
        if (ret >= 10000000) {
            return -1;
        }
        return ret;
    }
}
// @lc code=end

