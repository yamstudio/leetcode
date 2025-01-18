/*
 * @lc app=leetcode id=1250 lang=java
 *
 * [1250] Check If It Is a Good Array
 */

// @lc code=start
class Solution {
    public boolean isGoodArray(int[] nums) {
        int d = 0;
        for (int num : nums) {
            d = gcd(d, num);
        }
        return d == 1;
    }

    private static int gcd(int x, int y) {
        return y == 0 ? x : gcd(y, x % y);
    }
}
// @lc code=end

