/*
 * @lc app=leetcode id=1318 lang=java
 *
 * [1318] Minimum Flips to Make a OR b Equal to c
 */

// @lc code=start
class Solution {
    public int minFlips(int a, int b, int c) {
        int ret = 0;
        while (a != 0 || b != 0 || c != 0) {
            if ((c & 1) == 0) {
                ret += (b & 1) + (a & 1);
            } else {
                ret += 1 - ((b | a) & 1);
            }
            a >>= 1;
            b >>= 1;
            c >>= 1;
        }
        return ret;
    }
}
// @lc code=end

