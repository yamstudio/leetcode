/*
 * @lc app=leetcode id=1662 lang=java
 *
 * [1662] Check If Two String Arrays are Equivalent
 */

// @lc code=start
class Solution {
    public boolean arrayStringsAreEqual(String[] word1, String[] word2) {
        int i1 = 0, i2 = 0, j1 = 0, j2 = 0;
        while (i1 < word1.length && i2 < word2.length) {
            char c1 = word1[i1].charAt(j1++), c2 = word2[i2].charAt(j2++);
            if (c1 != c2) {
                return false;
            }
            if (j1 == word1[i1].length()) {
                j1 = 0;
                ++i1;
            }
            if (j2 == word2[i2].length()) {
                j2 = 0;
                ++i2;
            }
        }
        return i1 == word1.length && i2 == word2.length;
    }
}
// @lc code=end

