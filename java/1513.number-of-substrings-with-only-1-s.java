/*
 * @lc app=leetcode id=1513 lang=java
 *
 * [1513] Number of Substrings With Only 1s
 */

// @lc code=start
class Solution {
    public int numSub(String s) {
        int n = s.length(), ret = 0, acc = 0;
        for (int i = 0; i < n; ++i) {
            if (s.charAt(i) == '0') {
                acc = 0;
                continue;
            }
            acc = (acc + 1) % 1000000007;
            ret = (ret + acc) % 1000000007;
        }
        return ret;
    }
}
// @lc code=end

