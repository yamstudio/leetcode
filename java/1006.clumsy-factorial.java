/*
 * @lc app=leetcode id=1006 lang=java
 *
 * [1006] Clumsy Factorial
 */

// @lc code=start
class Solution {
    public int clumsy(int n) {
        int ret = 0, acc = 1;
        for (int i = 0; i < n; ++i) {
            int d = n - i, r = i % 4;
            if (r < 2) {
                acc *= d;
            } else if (r == 2) {
                ret += acc / d;
                acc = -1;
            } else {
                ret += d;
            }
        }
        if (n % 4 < 3 && n % 4 > 0) {
            ret += acc;
        }
        return ret;
    }
}
// @lc code=end

