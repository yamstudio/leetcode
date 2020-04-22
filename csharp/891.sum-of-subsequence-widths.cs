/*
 * @lc app=leetcode id=891 lang=csharp
 *
 * [891] Sum of Subsequence Widths
 */

using System;

// @lc code=start
public class Solution {
    public int SumSubseqWidths(int[] A) {
        long ret = 0, n = A.Length, t = 1;
        Array.Sort(A);
        for (int i = 0; i < n; ++i) {
            ret = (ret + A[i] * t - A[n - i - 1] * t) % 1000000007;
            t = (t << 1) % 1000000007;
        }
        return (int)ret;
    }
}
// @lc code=end

