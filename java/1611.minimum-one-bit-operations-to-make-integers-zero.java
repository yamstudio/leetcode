/*
 * @lc app=leetcode id=1611 lang=java
 *
 * [1611] Minimum One Bit Operations to Make Integers Zero
 */

// @lc code=start
class Solution {
    public int minimumOneBitOperations(int n) {
        if (n <= 1) {
            return n;
        }
        int b = 0;
        while ((1 << b) <= n) {
            ++b;
        }
        return ((1 << b) - 1) - minimumOneBitOperations(n - (1 << (b - 1)));
    }
}
// @lc code=end

