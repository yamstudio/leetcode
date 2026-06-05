/*
 * @lc app=leetcode id=1763 lang=java
 *
 * [1763] Longest Nice Substring
 */

import java.util.Set;
import java.util.HashSet;

// @lc code=start
class Solution {
    public String longestNiceSubstring(String s) {
        if (s.length() < 2) {
            return "";
        }
        int n = s.length();
        Set<Character> chars = new HashSet<>();
        for (int i = 0; i < n; ++i) {
            chars.add(s.charAt(i));
        }
        for (int i = 0; i < n; ++i) {
            char c = s.charAt(i);
            if (chars.contains(Character.toLowerCase(c)) && chars.contains(Character.toUpperCase(c))) {
                continue;
            }
            String l = longestNiceSubstring(s.substring(0, i)), r = longestNiceSubstring(s.substring(i + 1));
            return l.length() >= r.length() ? l : r;
        }
        return s;
    }
}
// @lc code=end

