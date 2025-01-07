/*
 * @lc app=leetcode id=1201 lang=java
 *
 * [1201] Ugly Number III
 */

// @lc code=start
class Solution {
    public int nthUglyNumber(int n, int a, int b, int c) {
        long ab = (long)a * (long)b / gcd(a, b), bc = (long)b * (long)c / gcd(b, c), ac = (long)a * (long)c / gcd(a, c), abc = (long)a * bc / gcd(a, (int)bc), l = 0, r = 2000000001;
        while (l < r) {
            long m = (l + r) / 2, count = m / a + m / b + m / c - m / ab - m / bc - m / ac + m / abc;
            if (count < n) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        return (int)l;
    }

    private static int gcd(int a, int b) {
        return b == 0 ? a : gcd(b, a % b);
    }
}
// @lc code=end

