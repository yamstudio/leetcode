/*
 * @lc app=leetcode id=1684 lang=java
 *
 * [1684] Count the Number of Consistent Strings
 */

// @lc code=start
class Solution {
    public int countConsistentStrings(String allowed, String[] words) {
        int a = 0, ret = 0, m = allowed.length();
        for (int i = 0; i < m; ++i) {
            a |= (1 << (allowed.charAt(i) - 'a'));
        }
        for (String w : words) {
            int n = w.length(), i;
            for (i = 0; i < n && (a & (1 << (w.charAt(i) - 'a'))) != 0; ++i);
            if (i == n) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

