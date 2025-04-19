/*
 * @lc app=leetcode id=1593 lang=java
 *
 * [1593] Split a String Into the Max Number of Unique Substrings
 */

import java.util.HashSet;
import java.util.Set;

// @lc code=start

class Solution {
    public int maxUniqueSplit(String s) {
        return maxUniqueSplit(s, 0, new HashSet<>());
    }

    private static int maxUniqueSplit(String s, int i, Set<String> used) {
        int n = s.length();
        if (i == n) {
            return 0;
        }
        int ret = 0;
        for (int j = i; j < n; ++j) {
            String sub = s.substring(i, j + 1);
            if (used.add(sub)) {
                ret = Math.max(ret, 1 + maxUniqueSplit(s, j + 1, used));
                used.remove(sub);
            }
        }
        return ret;
    }
}
// @lc code=end

