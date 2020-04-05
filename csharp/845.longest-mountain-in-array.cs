/*
 * @lc app=leetcode id=845 lang=csharp
 *
 * [845] Longest Mountain in Array
 */

using System;

// @lc code=start
public class Solution {
    public int LongestMountain(int[] A) {
        int ret = 0, left = 0, peak = 0;
        for (int i = 1; i < A.Length; ++i) {
            if (A[i] > A[i - 1]) {
                if (peak < i - 1) {
                    left = i - 1;
                }
                peak = i;
            } else if (A[i] == A[i - 1]) {
                left = i;
                peak = i;
            } else {
                if (left != peak) {
                    ret = Math.Max(i - left + 1, ret);
                } else {
                    left = i;
                    peak = i;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

