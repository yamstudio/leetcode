/*
 * @lc app=leetcode id=1002 lang=java
 *
 * [1002] Find Common Characters
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

// @lc code=start

class Solution {
    public List<String> commonChars(String[] words) {
        int[] ret = new int[] {
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE,
            Integer.MAX_VALUE
        };
        int n = words.length, size = Integer.MAX_VALUE;
        for (int i = 0; size > 0 && i < n; ++i) {
            int[] count = new int[26];
            String w = words[i];
            int l = w.length();
            for (int j = 0; j < l; ++j) {
                int c = w.charAt(j) - 'a';
                ++count[c];
            }
            int s = 0;
            for (int c = 0 ; c < 26; ++c) {
                ret[c] = Math.min(ret[c], count[c]);
                s += ret[c];
            }
            size = s;
        }
        if (size == 0) {
            return Collections.emptyList();
        }
        List<String> retList = new ArrayList<>(size);
        for (int c = 0 ; c < 26; ++c) {
            int l = ret[c];
            while (l-- > 0) {
                retList.add(new String(new char[] { (char)('a' + c) }));
            }
        }
        return retList;
    }
}
// @lc code=end

