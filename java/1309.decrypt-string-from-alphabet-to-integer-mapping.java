/*
 * @lc app=leetcode id=1309 lang=java
 *
 * [1309] Decrypt String from Alphabet to Integer Mapping
 */

// @lc code=start
class Solution {
    public String freqAlphabets(String s) {
        int n = s.length();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; ++i) {
            int c = s.charAt(i) - '0';
            if (c <= 2 && i + 2 < n && s.charAt(i + 2) == '#') {
                c = c * 10 + (s.charAt(i + 1) - '0');
                i += 2;
            }
            sb.append((char)(c - 1 + (int)'a'));
        }
        return sb.toString();
    }
}
// @lc code=end

