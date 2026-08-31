/*
 * @lc app=leetcode id=1807 lang=java
 *
 * [1807] Evaluate the Bracket Pairs of a String
 */

import java.util.HashMap;
import java.util.List;
import java.util.Map;

// @lc code=start
class Solution {
    public String evaluate(String s, List<List<String>> knowledge) {
        Map<String, String> map = new HashMap<>(knowledge.size());
        for (List<String> entry : knowledge) {
            map.put(entry.get(0), entry.get(1));
        }
        StringBuilder sb = new StringBuilder();
        int n = s.length();
        for (int i = 0; i < n; ++i) {
            char c = s.charAt(i);
            if (c != '(') {
                sb.append(c);
                continue;
            }
            int j;
            StringBuilder keyBuilder = new StringBuilder();
            for (j = i + 1; s.charAt(j) != ')'; ++j) {
                keyBuilder.append(s.charAt(j));
            }
            i = j;
            String val = map.getOrDefault(keyBuilder.toString(), "?");
            sb.append(val);
        }
        return sb.toString();
    }
}
// @lc code=end

