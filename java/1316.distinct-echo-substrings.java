/*
 * @lc app=leetcode id=1316 lang=java
 *
 * [1316] Distinct Echo Substrings
 */

import java.util.HashSet;
import java.util.Set;

// @lc code=start
class Solution {
    public int distinctEchoSubstrings(String text) {
        Set<String> seen = new HashSet<>();
        int n = text.length();
        for (int l = 1; l <= n / 2; ++l) {
            int count = 0;
            for (int i = 0; i + l < n; ++i) {
                if (text.charAt(i) == text.charAt(i + l)) {
                    ++count;
                } else {
                    count = 0;
                }
                if (count == l) {
                    seen.add(text.substring(i - l + 1, i + 1));
                    --count;
                }
            }
        }
        return seen.size();
    }
}
// @lc code=end

