/*
 * @lc app=leetcode id=454 lang=csharp
 *
 * [454] 4Sum II
 */

using System.Collections.Generic;

public class Solution {
    public int FourSumCount(int[] A, int[] B, int[] C, int[] D) {
        int n = A.Length, ret = 0;
        IDictionary<int, int> count = new Dictionary<int, int>();
        for (int i = 0; i < n; ++i) {
            int curr = A[i];
            for (int j = 0; j < n; ++j) {
                int sum = curr + B[j];
                count[sum] = 1 + (count.ContainsKey(sum) ? count[sum] : 0);
            }
        }
        for (int i = 0; i < n; ++i) {
            int curr = C[i];
            for (int j = 0; j < n; ++j) {
                int sum = curr + D[j];
                if (count.ContainsKey(-sum)) {
                    ret += count[-sum];
                }
            }
        }
        return ret;
    }
}

