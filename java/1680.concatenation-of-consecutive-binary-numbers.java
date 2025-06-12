/*
 * @lc app=leetcode id=1680 lang=java
 *
 * [1680] Concatenation of Consecutive Binary Numbers
 */

// @lc code=start
class Solution {
    public int concatenatedBinary(int n) {
        long ret = 0;
        for (int i = 1; i <= n; ++i) {
            int v = i, l = 0;
            while (v > 0) {
                ++l;
                v >>= 1;
            }
            ret = ((ret << l) + i) % 1000000007;
        }
        return (int)ret;
    }
}
// @lc code=end

