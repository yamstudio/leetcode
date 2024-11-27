/*
 * @lc app=leetcode id=953 lang=java
 *
 * [953] Verifying an Alien Dictionary
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start
class Solution {
    public boolean isAlienSorted(String[] words, String order) {
        Map<Character, Integer> charToOrd = new HashMap<>(order.length() + 1);
        for (int i = 0; i < order.length(); ++i) {
            charToOrd.put(order.charAt(i), i);
        }
        charToOrd.put('#', -1);
        for (int i = words.length - 1; i >= 1; --i) {
            if (!lessOrEqual(words[i - 1], words[i], charToOrd)) {
                return false;
            }
        }
        return true;
    }

    private boolean lessOrEqual(String w1, String w2, Map<Character, Integer> charToOrd) {
        int n = Math.max(w1.length(), w2.length());
        for (int i = 0; i < n; ++i) {
            Character c1 = i < w1.length() ? w1.charAt(i) : '#';
            Character c2 = i < w2.length() ? w2.charAt(i) : '#';
            if (c1 != c2) {
                return charToOrd.get(c1) < charToOrd.get(c2);
            }
        }
        return true;
    }
}
// @lc code=end

