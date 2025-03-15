/*
 * @lc app=leetcode id=1456 lang=java
 *
 * [1456] Maximum Number of Vowels in a Substring of Given Length
 */

// @lc code=start
class Solution {
    private static final int VOWELS = 
        1 << ('a' - 'a')
        | 1 << ('e' - 'a')
        | 1 << ('i' - 'a')
        | 1 << ('o' - 'a')
        | 1 << ('u' - 'a');

    public int maxVowels(String s, int k) {
        int ret = 0, acc = 0, n = s.length();
        for (int i = 0; i < n; ++i) {
            if ((1 << (s.charAt(i) - 'a') & VOWELS) != 0) {
                ++acc;
            }
            if (i >= k && (1 << (s.charAt(i - k) - 'a') & VOWELS) != 0) {
                --acc;
            }
            ret = Math.max(ret, acc);
        }
        return ret;
    }
}
// @lc code=end

