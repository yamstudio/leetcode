/*
 * @lc app=leetcode id=1784 lang=java
 *
 * [1784] Check if Binary String Has at Most One Segment of Ones
 */

// @lc code=start
class Solution {
    public boolean checkOnesSegment(String s) {
        int n = s.length(), acc = s.charAt(0) - '0';
        for (int i = 1; i < n && acc < 3; ++i) {
            if (s.charAt(i) != s.charAt(i - 1)) {
                ++acc;
            }
        }
        return acc <= 2;
    }
}
// @lc code=end

