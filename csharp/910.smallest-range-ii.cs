/*
 * @lc app=leetcode id=910 lang=csharp
 *
 * [910] Smallest Range II
 */

using System;

// @lc code=start
public class Solution {
    public int SmallestRangeII(int[] A, int K) {
        int ret, left, right, n = A.Length;
        Array.Sort(A);
        left = A[0] + K;
        right = A[n - 1] - K;
        ret = A[n - 1] - A[0];
        for (int i = 0; i < n - 1; ++i) {
            int r = Math.Max(right, A[i] + K), l = Math.Min(left, A[i + 1] - K);
            ret = Math.Min(ret, r - l);
        }
        return ret;
    }
}
// @lc code=end

