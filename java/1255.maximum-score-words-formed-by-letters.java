/*
 * @lc app=leetcode id=1255 lang=java
 *
 * [1255] Maximum Score Words Formed by Letters
 */

// @lc code=start
class Solution {
    public int maxScoreWords(String[] words, char[] letters, int[] score) {
        int[] count = new int[26];
        for (char c : letters) {
            ++count[c - 'a'];
        }
        return helper(words, count, score, 0);
    }

    private int helper(String[] words, int[] count, int[] score, int curr) {
        int ret = 0;
        for (int i = curr; i < words.length; ++i) {
            String word = words[i];
            int len = word.length(), j, sc = 0;
            for (j = 0; j < len; ++j) {
                int c = word.charAt(j) - 'a';
                if (count[c] == 0) {
                    break;
                }
                sc += score[c];
                --count[c];
            }
            if (j == len) {
                ret = Math.max(ret, sc + helper(words, count, score, i + 1));
            }
            for (j--; j >= 0; --j) {
                ++count[word.charAt(j) - 'a'];
            }
        }
        return ret;
    }
}
// @lc code=end

