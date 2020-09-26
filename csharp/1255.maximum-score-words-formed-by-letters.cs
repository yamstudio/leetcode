/*
 * @lc app=leetcode id=1255 lang=csharp
 *
 * [1255] Maximum Score Words Formed by Letters
 */

using System;

// @lc code=start
public class Solution {
    
    private static int MaxScoreWordsRecurse(string[] words, int[] score, int[] count, int start) {
        int ret = 0;
        for (int i = start; i < words.Length; ++i) {
            string curr = words[i];
            bool isOkay = true;
            int p = 0;
            foreach (char c in curr) {
                p += score[(int)c - (int)'a'];
                isOkay &= (--count[(int)c - (int)'a'] >= 0);
            }
            if (isOkay) {
                ret = Math.Max(ret, p + MaxScoreWordsRecurse(words, score, count, i + 1));
            }
            foreach (char c in curr) {
                ++count[(int)c - (int)'a'];
            }
        }
        return ret;
    }
    
    public int MaxScoreWords(string[] words, char[] letters, int[] score) {
        int[] count = new int[26];
        foreach (char c in letters) {
            ++count[(int)c - (int)'a'];
        }
        return MaxScoreWordsRecurse(words, score, count, 0);
    }
}
// @lc code=end

