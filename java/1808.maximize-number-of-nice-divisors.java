/*
 * @lc app=leetcode id=1808 lang=java
 *
 * [1808] Maximize Number of Nice Divisors
 */

// @lc code=start
class Solution {
    public int maxNiceDivisors(int primeFactors) {
        if (primeFactors <= 4) {
            return primeFactors;
        }
        long ret = 1, b = 3;
        for (int x = (primeFactors - 2) / 3; x > 0; x >>= 1) {
            if ((x & 1) == 1) {
                ret = (ret * b) % 1000000007;
            }
            b = b * b % 1000000007;
        }
        return (int)((ret * ((primeFactors - 2) % 3 + 2)) % 1000000007);
    }
}
// @lc code=end

