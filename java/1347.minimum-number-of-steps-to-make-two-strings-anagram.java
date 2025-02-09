/*
 * @lc app=leetcode id=1347 lang=java
 *
 * [1347] Minimum Number of Steps to Make Two Strings Anagram
 */

// @lc code=start
class Solution {
    public int minSteps(String s, String t) {
        int[] cs = new int[26], ct = new int[26];
        int n = s.length();
        for (int i = 0; i < n; ++i) {
            cs[s.charAt(i) - 'a']++;
            ct[t.charAt(i) - 'a']++;
        }
        int d = 0;
        for (int i = 0; i < 26; ++i) {
            d += Math.abs(cs[i] - ct[i]);
        }
        return d / 2;
    }
}
// @lc code=end

