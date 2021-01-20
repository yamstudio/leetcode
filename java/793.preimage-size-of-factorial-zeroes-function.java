/*
 * @lc app=leetcode id=793 lang=java
 *
 * [793] Preimage Size of Factorial Zeroes Function
 */

// @lc code=start
class Solution {
    public int preimageSizeFZF(int K) {
        long l = 0, r = 5 * (long)K + 5;
        while (l <= r) {
            long m = (l + r) / 2, t = m;
            int count = 0;
            while (t > 0) {
                count += t / 5;
                t /= 5;
            }
            if (count == K) {
                return 5;
            }
            if (count < K) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }
        return 0;
    }
}
// @lc code=end

