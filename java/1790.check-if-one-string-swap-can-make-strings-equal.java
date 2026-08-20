/*
 * @lc app=leetcode id=1790 lang=java
 *
 * [1790] Check if One String Swap Can Make Strings Equal
 */

// @lc code=start
class Solution {
    public boolean areAlmostEqual(String s1, String s2) {
        int n = s1.length(), d = 0;
        int[] count = new int[26];
        for (int i = 0; i < n; ++i) {
            char c1 = s1.charAt(i), c2 = s2.charAt(i);
            if (c1 == c2) {
                continue;
            }
            ++d;
            count[c1 - 'a']++;
            count[c2 - 'a']--;
            if (d >= 3) {
                return false;
            }
        }
        for (int c = 0; c < 26; ++c) {
            if (count[c] != 0) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

