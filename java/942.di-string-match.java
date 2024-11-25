/*
 * @lc app=leetcode id=942 lang=java
 *
 * [942] DI String Match
 */

// @lc code=start
class Solution {
    public int[] diStringMatch(String s) {
        int n = s.length();
        int[] ret = new int[n + 1];
        int dec = 0;
        int inc = 0;
        for (int i = 0; i < n; ++i) {
            if (s.charAt(i) == 'I') {
                ret[i + 1] = ++inc;
            } else {
                ret[i + 1] = --dec;
            }
        }
        for (int i = 0; i <= n; ++i) {
            ret[i] -= dec;
        }
        return ret;
    }
}
// @lc code=end

