/*
 * @lc app=leetcode id=1736 lang=java
 *
 * [1736] Latest Time by Replacing Hidden Digits
 */

// @lc code=start
class Solution {
    public String maximumTime(String time) {
        char[] ret = time.toCharArray();
        if (ret[0] == '?') {
            if (ret[1] == '?' || ret[1] <= '3') {
                ret[0] = '2';
            } else {
                ret[0] = '1';
            }
        }
        if (ret[1] == '?') {
            if (ret[0] == '2') {
                ret[1] = '3';
            } else {
                ret[1] = '9';
            }
        }
        if (ret[3] == '?') {
            ret[3] = '5';
        }
        if (ret[4] == '?') {
            ret[4] = '9';
        }
        return new String(ret);
    }
}
// @lc code=end

