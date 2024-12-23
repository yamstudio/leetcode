/*
 * @lc app=leetcode id=1081 lang=java
 *
 * [1081] Smallest Subsequence of Distinct Characters
 */

// @lc code=start
class Solution {
    public String smallestSubsequence(String s) {
        int[] count = new int[26];
        int n = s.length(), d = 0;
        for (int i = 0; i < n; ++i) {
            if (count[s.charAt(i) - 'a']++ == 0) {
                ++d;
            }
        }
        boolean[] used = new boolean[26];
        char[] ret = new char[d];
        int i = 0;
        for (int j = 0; j < n && i < d; ++j) {
            int c = s.charAt(j) - 'a';
            --count[c];
            if (used[c]) {
                continue;
            }
            while (i > 0 && count[ret[i - 1] - 'a'] > 0 && c < (ret[i - 1] - 'a')) {
                used[ret[i - 1] - 'a'] = false;
                --i;
            }
            ret[i++] = (char)(c + (int)'a');
            used[c] = true;
        }
        return new String(ret);
    }
}
// @lc code=end

