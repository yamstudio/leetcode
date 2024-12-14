/*
 * @lc app=leetcode id=1015 lang=java
 *
 * [1015] Smallest Integer Divisible by K
 */

// @lc code=start
class Solution {
    public int smallestRepunitDivByK(int k) {
        if (k % 2 == 0 || k % 5 == 0) {
            return -1;
        }
        int d = 0;
        for (int i = 1; i <= k; ++i) {
            d = (d * 10 + 1) % k;
            if (d == 0) {
                return i;
            }
        }
        return -1;
    }
}
// @lc code=end

