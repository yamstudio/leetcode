/*
 * @lc app=leetcode id=1492 lang=java
 *
 * [1492] The kth Factor of n
 */

// @lc code=start
class Solution {
    public int kthFactor(int n, int k) {
        int d;
        for (d = 1; d * d <= n; ++d) {
            if (n % d != 0) {
                continue;
            }
            --k;
            if (k == 0) {
                return d;
            }
        }
        while (d * d >= n) {
            --d;
        }
        for (; d >= 1; --d) {
            if (n % d != 0) {
                continue;
            }
            --k;
            if (k == 0) {
                return n / d;
            }
        }
        return -1;
    }
}
// @lc code=end

