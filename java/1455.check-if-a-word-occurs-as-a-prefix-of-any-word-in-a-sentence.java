/*
 * @lc app=leetcode id=1455 lang=java
 *
 * [1455] Check If a Word Occurs As a Prefix of Any Word in a Sentence
 */

// @lc code=start
class Solution {
    public int isPrefixOfWord(String sentence, String searchWord) {
        int n = sentence.length(), m = searchWord.length(), w = 1, i = 0;
        while (i < n) {
            int j;
            for (j = 0; j < m && i + j < n && sentence.charAt(i + j) == searchWord.charAt(j); ++j);
            if (j == m) {
                return w;
            }
            for (i += j; i < n && sentence.charAt(i) != ' '; ++i);
            ++i;
            ++w;
        }
        return -1;
    }
}
// @lc code=end

