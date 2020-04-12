/*
 * @lc app=leetcode id=870 lang=csharp
 *
 * [870] Advantage Shuffle
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int[] AdvantageCount(int[] A, int[] B) {
        int n = A.Length, left = 0, right = n - 1;
        int[] ret = new int[n];
        Array.Sort(A);
        foreach (int i in Enumerable.Range(0, n).OrderByDescending(j => B[j])) {
            if (B[i] < A[right]) {
                ret[i] = A[right--];
            } else {
                ret[i] = A[left++];
            }
        }
        return ret;
    }
}
// @lc code=end

