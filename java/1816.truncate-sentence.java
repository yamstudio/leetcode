/*
 * @lc app=leetcode id=1816 lang=java
 *
 * [1816] Truncate Sentence
 */

// @lc code=start
class Solution {
    public String truncateSentence(String s, int k) {
        StringBuilder sb = new StringBuilder();
        int n = s.length();
        for (int i = 0; i < n; ++i) {
            char c = s.charAt(i);
            if (c == ' ') {
                --k;
                if (k == 0) {
                    break;
                }
            }
            sb.append(c);
        }
        return sb.toString();
    }
}
// @lc code=end

