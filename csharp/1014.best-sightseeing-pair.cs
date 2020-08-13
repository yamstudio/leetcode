/*
 * @lc app=leetcode id=1014 lang=csharp
 *
 * [1014] Best Sightseeing Pair
 */

using System;

// @lc code=start
public class Solution {
    public int MaxScoreSightseeingPair(int[] A) {
        int mi = 0, ret = 0;
        for (int j = 1; j < A.Length; ++j) {
            ret = Math.Max(ret, A[j] - j + A[mi] + mi);
            if (A[j] + j > A[mi] + mi) {
                mi = j;
            }
        }
        return ret;
    }
}
// @lc code=end

