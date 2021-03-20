/*
 * @lc app=leetcode id=926 lang=java
 *
 * [926] Flip String to Monotone Increasing
 */

// @lc code=start
class Solution {
    public int minFlipsMonoIncr(String S) {
        int zeros = 0, acc = 0, ret = 0, n = S.length();
        for (int i = 0; i < n; ++i) {
            if (S.charAt(i) == '0') {
                ++zeros;
            }
        }
        ret = n - zeros;
        for (int i = 0; i < n; ++i) {
            ret = Math.min(zeros + acc, ret);
            if (S.charAt(i) == '0') {
                --zeros;
            } else {
                ++acc;
            }
        }
        return ret;
    }
}
// @lc code=end

