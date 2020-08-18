/*
 * @lc app=leetcode id=1031 lang=csharp
 *
 * [1031] Maximum Sum of Two Non-Overlapping Subarrays
 */

using System;

// @lc code=start
public class Solution {
    public int MaxSumTwoNoOverlap(int[] A, int L, int M) {
        int n = A.Length;
        for (int i = 1; i < n; ++i) {
            A[i] += A[i - 1];
        }
        int ret = A[L + M - 1], lm = A[L - 1], mm = A[M - 1];
        for (int i = L + M; i < n; ++i) {
            lm = Math.Max(lm, A[i - M] - A[i - L - M]);
            mm = Math.Max(mm, A[i - L] - A[i - L - M]);
            ret = Math.Max(A[i] + Math.Max(lm - A[i - M], mm - A[i - L]), ret);
        }
        return ret;
    }
}
// @lc code=end

