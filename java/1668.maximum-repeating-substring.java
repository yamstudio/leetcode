/*
 * @lc app=leetcode id=1668 lang=java
 *
 * [1668] Maximum Repeating Substring
 */

// @lc code=start
class Solution {
    public int maxRepeating(String sequence, String word) {
        int m = sequence.length(), n = word.length(), p = 1 + (m / n) * n;
        StringBuilder sb = new StringBuilder(p);
        for (int t = m / n; t > 0; --t) {
            sb.append(word);
        }
        sb.append('$');
        String pattern = sb.toString();
        int[] lps = new int[p];
        int l = 0;
        for (int i = 1; i < p; ++i) {
            while (l > 0 && pattern.charAt(i) != pattern.charAt(l)) {
                l = lps[l - 1];
            }
            if (pattern.charAt(i) == pattern.charAt(l)) {
                ++l;
            }
            lps[i] = l;
        }
        l = 0;
        int ret = 0;
        for (int i = 0; i < m; ++i) {
            while (l > 0 && sequence.charAt(i) != pattern.charAt(l)) {
                l = lps[l - 1];
            }
            if (sequence.charAt(i) == pattern.charAt(l)) {
                ++l;
            }
            ret = Math.max(ret, l / n);
        }
        return ret;
    }
}
// @lc code=end

