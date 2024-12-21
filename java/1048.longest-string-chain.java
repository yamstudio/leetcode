/*
 * @lc app=leetcode id=1048 lang=java
 *
 * [1048] Longest String Chain
 */

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

// @lc code=start

class Solution {
    public int longestStrChain(String[] words) {
        Map<Integer, Set<String>> lenToWords = new HashMap<>(16);
        Map<String, Integer> wordToChainLen = new HashMap<>();
        int ret = 1;
        for (String w : words) {
            lenToWords.computeIfAbsent(w.length(), ignored -> new HashSet<>()).add(w);
            wordToChainLen.put(w, 1);
        }
        for (int l = 2; l <= 16; ++l) {
            Set<String> pres = lenToWords.get(l - 1), currs = lenToWords.get(l);
            if (pres == null || currs == null) {
                continue;
            }
            for (String curr : currs) {
                for (String pre : pres) {
                    if (!isPredecessor(pre, curr)) {
                        continue;
                    }
                    wordToChainLen.put(curr, Math.max(wordToChainLen.get(curr), wordToChainLen.get(pre) + 1));
                }
                ret = Math.max(ret, wordToChainLen.get(curr));
            }
        }
        return ret;
    }

    private static boolean isPredecessor(String p, String w) {
        int m = p.length(), n = w.length();
        if (m != n - 1) {
            return false;
        }
        int i = 0, j = 0;
        while (i < m && j < n && i >= j - 1) {
            if (p.charAt(i) == w.charAt(j)) {
                ++i;
                ++j;
            } else {
                ++j;
            }
        }
        return i == m;
    }
}
// @lc code=end

