/*
 * @lc app=leetcode id=1147 lang=java
 *
 * [1147] Longest Chunked Palindrome Decomposition
 */

// @lc code=start
class Solution {
    public int longestDecomposition(String text) {
        int n = text.length();
        if (n == 0) {
            return 0;
        }
        StringBuilder l = new StringBuilder(), r = new StringBuilder();
        for (int i = 0; i < n / 2; ++i) {
            l.append(text.charAt(i));
            r.insert(0, text.charAt(n - 1 - i));
            if (l.toString().equals(r.toString())) {
                return 2 + longestDecomposition(text.substring(i + 1, n - 1 - i));
            }
        }
        return 1;
    }
}
// @lc code=end

