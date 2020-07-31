/*
 * @lc app=leetcode id=978 lang=csharp
 *
 * [978] Longest Turbulent Subarray
 */

using System;

// @lc code=start
public class Solution {
    public int MaxTurbulenceSize(int[] A) {
        int ret = 1, inc = 1, dec = 1, n = A.Length;
        for (int i = 1; i < n; ++i) {
            if (A[i] > A[i - 1]) {
                inc = dec + 1;
                dec = 1;
                ret = Math.Max(ret, inc);
            } else if (A[i] < A[i - 1]) {
                dec = inc + 1;
                inc = 1;
                ret = Math.Max(ret, dec);
            } else {
                inc = 1;
                dec = 1;
            }
        }
        return ret;
    }
}
// @lc code=end

