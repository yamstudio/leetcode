/*
 * @lc app=leetcode id=1657 lang=java
 *
 * [1657] Determine if Two Strings Are Close
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public boolean closeStrings(String word1, String word2) {
        int n = word1.length();
        if (n != word2.length()) {
            return false;
        }
        int[] counts1 = new int[26], counts2 = new int[26];
        for (int i = 0; i < n; ++i) {
            ++counts1[word1.charAt(i) - 'a'];
            ++counts2[word2.charAt(i) - 'a'];
        }
        Map<Integer, Integer> cc = new HashMap<>();
        for (int i = 0; i < 26; ++i) {
            int c1 = counts1[i], c2 = counts2[i];
            if (c1 == 0) {
                if (c2 != 0) {
                    return false;
                }
                continue;
            }
            if (c2 == 0) {
                return false;
            }
            cc.put(c1, cc.getOrDefault(c1, 0) + 1);
            cc.put(c2, cc.getOrDefault(c2, 0) - 1);
        }
        for (int v : cc.values()) {
            if (v != 0) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

