/*
 * @lc app=leetcode id=1520 lang=java
 *
 * [1520] Maximum Number of Non-Overlapping Substrings
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public List<String> maxNumOfSubstrings(String s) {
        List<String> ret = new ArrayList<>();
        int n = s.length();
        int[] l = new int[26], r = new int[26];
        for (int i = 0; i < 26; ++i) {
            l[i] = n;
        }
        for (int i = 0; i < n; ++i) {
            int c = s.charAt(i) - 'a';
            l[c] = Math.min(l[c], i);
            r[c] = i;
        }
        int mr = -1;
        for (int i = 0; i < n; ++i) {
            int c = s.charAt(i) - 'a';
            if (l[c] != i) {
                continue;
            }
            int nr = r[c], j;
            for (j = i + 1; j < nr; ++j) {
                int nc = s.charAt(j) - 'a';
                if (l[nc] < i) {
                    break;
                }
                nr = Math.max(nr, r[nc]);
            }
            if (j < nr) {
                continue;
            }
            if (i <= mr) {
                ret.removeLast();
            }
            ret.add(s.substring(i, nr + 1));
            mr = nr;
        }
        return ret;
    }
}
// @lc code=end

