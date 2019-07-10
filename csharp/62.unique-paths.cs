/*
 * @lc app=leetcode id=62 lang=csharp
 *
 * [62] Unique Paths
 */
public class Solution {
    public int UniquePaths(int m, int n) {
        --m;
        --n;
        if (m == 0 || n == 0) {
            return 1;
        }
        long p = m + n, d1 = 1, d2 = 1;
        for (long k = Math.Min(m, n); k > 0; --k) {
            d1 *= k;
            d2 *= (p + 1 - k);
        }
        return (int) (d2 / d1);
    }
}

