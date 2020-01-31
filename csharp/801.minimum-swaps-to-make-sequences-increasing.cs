/*
 * @lc app=leetcode id=801 lang=csharp
 *
 * [801] Minimum Swaps To Make Sequences Increasing
 */

using System;

// @lc code=start
public class Solution {
    public int MinSwap(int[] A, int[] B) {
        int n = A.Length;
        int[] swap = new int[n], keep = new int[n];
        for (int i = 1; i < n; ++i) {
            swap[i] = n;
            keep[i] = n;
        }
        swap[0] = 1;
        for (int i = 1; i < n; ++i) {
            if (A[i] > A[i - 1] && B[i] > B[i - 1]) {
                keep[i] = keep[i - 1];
                swap[i] = swap[i - 1] + 1;
            }
            if (A[i] > B[i - 1] && B[i] > A[i - 1]) {
                swap[i] = Math.Min(swap[i], keep[i - 1] + 1);
                keep[i] = Math.Min(swap[i - 1], keep[i]);
            }
        }
        return Math.Min(swap[n - 1], keep[n - 1]);
    }
}
// @lc code=end

