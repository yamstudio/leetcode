/*
 * @lc app=leetcode id=413 lang=csharp
 *
 * [413] Arithmetic Slices
 */
public class Solution {
    public int NumberOfArithmeticSlices(int[] A) {
        int len = 0, ret = 0;
        for (int i = 2; i < A.Length; ++i) {
            if ((long) A[i] - (long) A[i - 1] == (long) A[i - 1] - (long) A[i - 2]) {
                ret += ++len;
            } else {
                len = 0;
            }
        }
        return ret;
    }
}

