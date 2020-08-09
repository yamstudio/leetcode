/*
 * @lc app=leetcode id=1004 lang=csharp
 *
 * [1004] Max Consecutive Ones III
 */

using System;

// @lc code=start
public class Solution {
    public int LongestOnes(int[] A, int K) {
        int l = 0, ret = 0, n = A.Length, z = 0;
        for (int r = 0; r < n; ++r) {
            if (A[r] == 0) {
                ++z;
            }
            while (z > K) {
                if (A[l++] == 0) {
                    --z;
                }
            }
            ret = Math.Max(ret, r - l + 1);
        }
        return ret;
    }
}
// @lc code=end

