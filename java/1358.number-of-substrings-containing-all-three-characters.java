/*
 * @lc app=leetcode id=1358 lang=java
 *
 * [1358] Number of Substrings Containing All Three Characters
 */

// @lc code=start
class Solution {
    public int numberOfSubstrings(String s) {
        int n = s.length(), ret = 0;
        int[] prev = new int[] { -1, -1, -1 };
        for (int i = 0; i < n; ++i) {
            int c = s.charAt(i) - 'a';
            prev[c] = i;
            ret += 1 + Math.min(prev[0], Math.min(prev[1], prev[2]));
        }
        return ret;
    }
}
// @lc code=end

