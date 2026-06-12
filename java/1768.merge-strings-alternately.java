/*
 * @lc app=leetcode id=1768 lang=java
 *
 * [1768] Merge Strings Alternately
 */

// @lc code=start
class Solution {
    public String mergeAlternately(String word1, String word2) {
        int l1 = word1.length(), l2 = word2.length();
        StringBuilder sb = new StringBuilder(l1 + l2);
        for (int i = 0; i < l1 || i < l2; ++i) {
            if (i < l1) {
                sb.append(word1.charAt(i));
            }
            if (i < l2) {
                sb.append(word2.charAt(i));
            }
        }
        return sb.toString();
    }
}
// @lc code=end

