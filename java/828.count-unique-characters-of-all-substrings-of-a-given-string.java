/*
 * @lc app=leetcode id=828 lang=java
 *
 * [828] Count Unique Characters of All Substrings of a Given String
 */

// @lc code=start
class Solution {
    public int uniqueLetterString(String s) {
        int ret = 0, acc = 0, n = s.length();
        int[] pp = new int[26], p = new int[26];
        for (int i = 0; i < n; ++i) {
            int c = (int)s.charAt(i) - (int)'A';
            acc = (acc + (i + 1) - p[c] - p[c] + pp[c]) % 1000000007;
            ret = (ret + acc) % 1000000007;
            pp[c] = p[c];
            p[c] = 1 + i;
        }
        return ret;
    }
}
// @lc code=end

