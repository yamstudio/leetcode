/*
 * @lc app=leetcode id=1702 lang=java
 *
 * [1702] Maximum Binary String After Change
 */

// @lc code=start
class Solution {
    public String maximumBinaryString(String binary) {
        int n = binary.length(), zeroes = 0, ones = 0;
        for (int i = 0; i < n; ++i) {
            if (binary.charAt(i) == '0') {
                ++zeroes;
            } else if (zeroes == 0) {
                ++ones;
            }
        }
        char[] ret = new char[n];
        for (int i = 0; i < n; ++i) {
            ret[i] = '1';
        }
        if (zeroes > 0) {
            ret[ones + zeroes - 1] = '0';
        }
        return new String(ret);
    }
}
// @lc code=end

