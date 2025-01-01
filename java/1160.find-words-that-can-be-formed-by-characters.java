/*
 * @lc app=leetcode id=1160 lang=java
 *
 * [1160] Find Words That Can Be Formed by Characters
 */

// @lc code=start
class Solution {
    public int countCharacters(String[] words, String chars) {
        int ret = 0, k = chars.length();
        int[] count = new int[26];
        for (int i = 0; i < k; ++i) {
            int c = chars.charAt(i) - 'a';
            count[c]++;
        }
        for (String w : words) {
            int[] wordCount = new int[26];
            int n = w.length(), i = 0;
            for (i = 0; i < n; ++i) {
                int c = w.charAt(i) - 'a';
                if (++wordCount[c] > count[c]) {
                    break;
                }
            }
            if (i == n) {
                ret += n;
            }
        }
        return ret;
    }
}
// @lc code=end

