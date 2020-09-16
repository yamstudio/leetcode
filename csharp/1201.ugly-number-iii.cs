/*
 * @lc app=leetcode id=1201 lang=csharp
 *
 * [1201] Ugly Number III
 */

// @lc code=start
public class Solution {

    private static long GetGcd(long a, long b) {
        return b == 0 ? a : GetGcd(b, a % b);
    }

    public int NthUglyNumber(int n, int a, int b, int c) {
        long ab = (long)a * (long)b / GetGcd((long)a, (long)b), bc = (long)b * (long)c / GetGcd((long)b, (long)c), ac = (long)a * (long)c / GetGcd((long)a, (long)c), abc = (long)a * bc / GetGcd((long)a, bc);
        long l = 1, r = 2000000001;
        while (l < r) {
            long m = l + (r - l) / 2, k = m / a + m / b + m / c - m / ab - m / bc - m / ac + m / abc;
            if (k < n) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        return (int)l;
    }
}
// @lc code=end

