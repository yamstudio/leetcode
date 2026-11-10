/*
 * @lc app=leetcode id=1837 lang=java
 *
 * [1837] Sum of Digits in Base K
 */

// @lc code=start
class Solution {
    public int sumBase(int n, int k) {
        int t = k, ret = 0;
        while (t < n) {
            t *= k;
        }
        while (n > 0) {
            ret += n / t;
            n = n % t;
            t /= k;
        }
        return ret;
    }
}
// @lc code=end

