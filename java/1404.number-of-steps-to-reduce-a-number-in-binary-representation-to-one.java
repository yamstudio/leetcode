/*
 * @lc app=leetcode id=1404 lang=java
 *
 * [1404] Number of Steps to Reduce a Number in Binary Representation to One
 */

// @lc code=start
class Solution {
    public int numSteps(String s) {
        int n = s.length(), ret = 0;
        boolean carry = false;
        for (int i = n - 1; i > 0; --i) {
            if ((s.charAt(i) == '1') ^ carry) {
                ret += 2;
                carry = true;
            } else {
                ++ret;
            }
        }
        return carry ? ret + 1 : ret;
    }
}
// @lc code=end

