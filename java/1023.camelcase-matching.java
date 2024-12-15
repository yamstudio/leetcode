/*
 * @lc app=leetcode id=1023 lang=java
 *
 * [1023] Camelcase Matching
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public List<Boolean> camelMatch(String[] queries, String pattern) {
        int n = queries.length;
        List<Boolean> ret = new ArrayList<>(n);
        for (int i = 0; i < n; ++i) {
            ret.add(match(queries[i], pattern));
        }
        return ret;
    }

    private boolean match(String query, String pattern) {
        int m = query.length(), n = pattern.length(), i = 0, j = 0;
        while (i < m && j < n) {
            int c = query.charAt(i);
            if (c >= 'a' && c <= 'z') {
                ++i;
                if (c == pattern.charAt(j)) {
                    ++j;
                }
                continue;
            }
            if (c != pattern.charAt(j)) {
                return false;
            }
            ++i;
            ++j;
        }
        if (j != n) {
            return false;
        }
        while (i < m) {
            int c = query.charAt(i);
            if (c >= 'A' && c <= 'Z') {
                return false;
            }
            ++i;
        }
        return true;
    }
}
// @lc code=end

