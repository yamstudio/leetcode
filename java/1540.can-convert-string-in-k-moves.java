/*
 * @lc app=leetcode id=1540 lang=java
 *
 * [1540] Can Convert String in K Moves
 */

// @lc code=start
class Solution {
    public boolean canConvertString(String s, String t, int k) {
        int[] count = new int[26];
        int n = s.length();
        if (n != t.length()) {
          return false;
        }
        for (int i = 0; i < n; ++i) {
            ++count[(26 + t.charAt(i) - s.charAt(i)) % 26];
        }
        for (int d = 1; d < 26; ++d) {
            if (k < d  + 26 * (count[d] - 1)) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

