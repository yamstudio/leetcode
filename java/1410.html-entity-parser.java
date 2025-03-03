/*
 * @lc app=leetcode id=1410 lang=java
 *
 * [1410] HTML Entity Parser
 */

import java.util.Map;

// @lc code=start

class Solution {

    private static final Map<String, Character> SPECIAL = Map.of(
        "&quot;", '"',
        "&apos;", '\'',
        "&amp;", '&',
        "&gt;", '>',
        "&lt;", '<',
        "&frasl;", '/'
    );

    public String entityParser(String text) {
        StringBuilder sb = new StringBuilder();
        int n = text.length();
        for (int i = 0; i < n; ++i) {
            char c = text.charAt(i);
            if (c != '&') {
                sb.append(c);
                continue;
            }
            boolean done = false;
            for (var entry : SPECIAL.entrySet()) {
                String key = entry.getKey();
                int k = key.length();
                if (i + k > n) {
                    continue;
                }
                boolean flag = true;
                for (int j = 1; j < k && flag; ++j) {
                    flag = text.charAt(i + j) == key.charAt(j);
                }
                if (flag) {
                    sb.append(entry.getValue());
                    i += k - 1;
                    done = true;
                    break;
                }
            }
            if (!done) {
                sb.append(c);
            }
        }
        return sb.toString();
    }
}
// @lc code=end

