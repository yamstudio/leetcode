/*
 * @lc app=leetcode id=1005 lang=csharp
 *
 * [1005] Maximize Sum Of Array After K Negations
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int LargestSumAfterKNegations(int[] A, int K) {
        int n = A.Length;
        Array.Sort(A);
        for (int i = 0; i < n && K > 0; ++i) {
            if (A[i] < 0) {
                A[i] = -A[i];
                --K;
            }
        }
        if (K % 2 == 0) {
            return A.Sum();
        }
        return A.Sum() - 2 * A.Min();
    }
}
// @lc code=end

