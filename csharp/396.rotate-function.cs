/*
 * @lc app=leetcode id=396 lang=csharp
 *
 * [396] Rotate Function
 */
public class Solution {
    public int MaxRotateFunction(int[] A) {
        int n = A.Length;
        long ret, sum = 0, curr = 0;
        for (int i = 0; i < n; ++i) {
            curr += (long) i * A[i];
            sum += A[i];
        }
        ret = curr;
        for (int i = 0; i < n - 1; ++i) {
            curr += (long) n * A[i] - sum;
            ret = Math.Max(curr, ret);
        }
        return (int) ret;
    }
}

