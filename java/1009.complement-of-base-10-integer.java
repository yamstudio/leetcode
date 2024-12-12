/*
 * @lc app=leetcode id=1009 lang=java
 *
 * [1009] Complement of Base 10 Integer
 */

// @lc code=start
class Solution {
    public int bitwiseComplement(int n) {
        if (n == 0) {
            return 1;
        }
        int ret = 0, k = 0;
        while (n != 0) {
            ret |= (1 & (1 ^ n)) << k;
            n >>= 1;
            ++k;
        }
        return ret;
    }
}
// @lc code=end

