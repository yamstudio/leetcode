/*
 * @lc app=leetcode id=966 lang=java
 *
 * [966] Vowel Spellchecker
 */

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

// @lc code=start

class Solution {

    private static final Set<Character> VOWELS = Set.of('a', 'e', 'i', 'o', 'u');

    public String[] spellchecker(String[] wordlist, String[] queries) {
        Set<String> words = new HashSet<>();
        Map<String, String> lowerToWord = new HashMap<>();
        Map<String, String> noVowelToWord = new HashMap<>();
        for (String w : wordlist) {
            words.add(w);
            lowerToWord.computeIfAbsent(w.toLowerCase(), ignored -> w);
            noVowelToWord.computeIfAbsent(toNoVowel(w), ignored -> w);
        }
        int n = queries.length;
        String[] ret = new String[n];
        for (int i = 0; i < n; ++i) {
            String w = queries[i];
            if (words.contains(w)) {
                ret[i] = w;
                continue;
            }
            String lower = lowerToWord.get(w.toLowerCase());
            if (lower != null) {
                ret[i] = lower;
                continue;
            }
            String noVowel = noVowelToWord.get(toNoVowel(w));
            if (noVowel != null) {
                ret[i] = noVowel;
                continue;
            }
            ret[i] = "";
        }
        return ret;
    }

    private static String toNoVowel(String word) {
        StringBuilder sb = new StringBuilder(word.length());
        for (char c : word.toLowerCase().toCharArray()) {
            if (VOWELS.contains(c)) {
                sb.append('.');
            } else {
                sb.append(c);
            }
        }
        return sb.toString();
    }
}
// @lc code=end

