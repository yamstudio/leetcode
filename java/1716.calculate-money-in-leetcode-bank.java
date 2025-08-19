/*
 * @lc app=leetcode id=1716 lang=java
 *
 * [1716] Calculate Money in Leetcode Bank
 */

// @lc code=start
class Solution {
    public int totalMoney(int n) {
        int w = n / 7, r = n % 7, ret = 0;
        for (int i = 1; i <= w; ++i) {
            ret += (i + i + 6) * 7 / 2;
        }
        ret += (w + 1 + w + r) * r / 2;
        return ret;
    }
}
// @lc code=end

