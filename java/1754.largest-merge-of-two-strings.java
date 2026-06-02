/*
 * @lc app=leetcode id=1754 lang=java
 *
 * [1754] Largest Merge Of Two Strings
 */

// @lc code=start
class Solution {
    public String largestMerge(String word1, String word2) {
        StringBuilder sb = new StringBuilder();
        int n1 = word1.length(), n2 = word2.length(), i1, i2;
        for (i1 = 0, i2 = 0; i1 < n1 && i2 < n2;) {
            if (greater(word1, i1, word2, i2)) {
                sb.append(word1.charAt(i1));
                ++i1;
            } else {
                sb.append(word2.charAt(i2));
                ++i2;
            }
        }
        for (; i1 < n1; ++i1) {
            sb.append(word1.charAt(i1));
        }
        for (; i2 < n2; ++i2) {
            sb.append(word2.charAt(i2));
        }
        return sb.toString();
    }

    private static boolean greater(String word1, int i1, String word2, int i2) {
        int n1 = word1.length(), n2 = word2.length(), j;
        for (j = 0; i1 + j < n1 && i2 + j < n2 && word1.charAt(i1 + j) == word2.charAt(i2 + j); ++j);
        if (i1 + j == n1) {
            return false;
        }
        if (i2 + j == n2) {
            return true;
        }
        return word1.charAt(i1 + j) > word2.charAt(i2 + j);
    }
}
// @lc code=end

