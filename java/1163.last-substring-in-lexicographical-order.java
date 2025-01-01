/*
 * @lc app=leetcode id=1163 lang=java
 *
 * [1163] Last Substring in Lexicographical Order
 */

// @lc code=start
class Solution {
    public String lastSubstring(String s) {
        int n = s.length(), l = 0, ret = 0, cand = 1;
        while (cand + l < n) {
            int curr = s.charAt(ret + l), next = s.charAt(cand + l);
            if (curr == next) {
                ++l;
                continue;
            }
            if (curr > next) {
                cand = cand + l + 1;
                l = 0;
                continue;
            }
            ret = Math.max(cand, ret + l + 1);
            cand = ret + 1;
            l = 0;
        }
        return s.substring(ret);
    }
}
// @lc code=end

