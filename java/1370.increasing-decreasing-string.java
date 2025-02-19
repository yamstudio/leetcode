/*
 * @lc app=leetcode id=1370 lang=java
 *
 * [1370] Increasing Decreasing String
 */

// @lc code=start
class Solution {
    public String sortString(String s) {
        int[] count = new int[26];
        int n = s.length();
        for (int i = 0; i < n; ++i) {
            ++count[s.charAt(i) - 'a'];
        }
        StringBuilder sb = new StringBuilder(n);
        while (sb.length() < n) {
            for (int i = 0; i < 26; ++i) {
                if (count[i] > 0) {
                    --count[i];
                    sb.append((char)(i + 'a'));
                }
            }
            for (int i = 25; i >= 0; --i) {
                if (count[i] > 0) {
                    --count[i];
                    sb.append((char)(i + 'a'));
                }
            }
        }
        return sb.toString();
    }
}
// @lc code=end

