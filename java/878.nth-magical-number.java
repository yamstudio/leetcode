/*
 * @lc app=leetcode id=878 lang=java
 *
 * [878] Nth Magical Number
 */

// @lc code=start
class Solution {

    private static int getGcd(int x, int y) {
        return x == 0 ? y : getGcd(y % x, x);
    }

    public int nthMagicalNumber(int n, int a, int b) {
        long lcm = (long)a * (long)b / (long)getGcd(a, b), l = (long)Math.min(a, b), r = (long)n * (long)Math.max(a, b);
        while (l < r) {
            long m = (l + r) / 2;
            if ((long)n > m / a + m / b - m / lcm) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        return (int)(l % 1000000007);
    }
}
// @lc code=end

