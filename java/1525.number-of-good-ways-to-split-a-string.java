/*
 * @lc app=leetcode id=1525 lang=java
 *
 * [1525] Number of Good Ways to Split a String
 */

// @lc code=start
class Solution {
    public int numSplits(String s) {
        int[][] indices = new int[26][];
        int n = s.length(), lc = 0, rc = 0;
        for (int i = 0; i < n; ++i) {
            int c = s.charAt(i) - 'a';
            int[] pair = indices[c];
            if (pair == null) {
                ++rc;
                pair = new int[] { i, i };
                indices[c] = pair;
            } else {
                pair[1] = i;
            }
        }
        int li;
        for (li = 0; lc < rc; ++li) {
            int c = s.charAt(li) - 'a';
            int[] pair = indices[c];
            if (pair[0] == li) {
                ++lc;
            }
            if (pair[1] == li) {
                --rc;
            }
        }
        int ri;
        for (ri = li; lc == rc; ++ri) {
            int c = s.charAt(ri) - 'a';
            int[] pair = indices[c];
            if (pair[0] == ri) {
                ++lc;
            }
            if (pair[1] == ri) {
                --rc;
            }
        }
        return ri - li;
    }
}
// @lc code=end

