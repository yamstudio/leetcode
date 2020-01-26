/*
 * @lc app=leetcode id=786 lang=csharp
 *
 * [786] K-th Smallest Prime Fraction
 */

// @lc code=start
public class Solution {
    public int[] KthSmallestPrimeFraction(int[] A, int K) {
        int n = A.Length;
        double l = 0.0, r = 1.0;
        while (true) {
            double m = (l + r) / 2.0;
            int count = 0, p = 0, q = 1, ip = 0, iq = 0;
            while (ip < n && iq < n && count <= K) {
                while (iq < n && (double)A[ip] / (double)A[iq] > m) {
                    ++iq;
                }
                count += n - iq;
                if (iq < n && p * A[iq] < A[ip] * q) {
                    p = A[ip];
                    q = A[iq];
                }
                ++ip;
            }
            if (count < K) {
                l = m;
            } else if (count == K) {
                return new int[] { p, q };
            } else {
                r = m;
            }
        }
    }
}
// @lc code=end

