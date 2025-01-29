/*
 * @lc app=leetcode id=1297 lang=java
 *
 * [1297] Maximum Number of Occurrences of a Substring
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int maxFreq(String s, int maxLetters, int minSize, int maxSize) {
        int n = s.length(), ret = 0, d = 0;
        int[] count = new int[26];
        Map<String, Integer> map = new HashMap<>();
        StringBuilder sb = new StringBuilder(minSize);
        for (int r = 0; r < n; ++r) {
            char c = s.charAt(r);
            if (count[c - 'a']++ == 0) {
                ++d;
            }
            if (r >= minSize) {
                if (count[s.charAt(r - minSize) - 'a']-- == 1) {
                    --d;
                }
                sb.deleteCharAt(0);
            }
            sb.append(c);
            if (r < minSize - 1 || d > maxLetters) {
                continue;
            }
            String k = sb.toString();
            int p = map.getOrDefault(k, 0) + 1;
            map.put(k, p);
            ret = Math.max(p, ret);
        }
        return ret;
    }
}
// @lc code=end

