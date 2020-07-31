/*
 * @lc app=leetcode id=977 lang=csharp
 *
 * [977] Squares of a Sorted Array
 */

// @lc code=start
public class Solution {
    public int[] SortedSquares(int[] A) {
        int n = A.Length, l = 0, r = n, i = 0;
        int[] ret = new int[n];
        while (l < r) {
            int m = (l + r) / 2;
            if (A[m] < 0) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        l = r - 1;
        while (l >= 0 && r < n) {
            int vl = -A[l], vr = A[r];
            if (vl <= vr) {
                ret[i++] = vl * vl;
                --l;
            } else {
                ret[i++] = vr * vr;
                ++r;
            }
        }
        while (l >= 0) {
            int vl = A[l--];
            ret[i++] = vl * vl;
        }
        while (r < n) {
            int vr = A[r++];
            ret[i++] = vr * vr;
        }
        return ret;
    }
}
// @lc code=end

