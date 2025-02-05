/*
 * @lc app=leetcode id=1323 lang=java
 *
 * [1323] Maximum 69 Number
 */

// @lc code=start
class Solution {
    public int maximum69Number(int num) {
        int tens = 1000;
        while (tens > 0 && ((num / tens) % 10) != 6) {
            tens /= 10;
        }
        return num + tens * 3;
    }
}
// @lc code=end

