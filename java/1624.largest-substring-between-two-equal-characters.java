/*
 * @lc app=leetcode id=1624 lang=java
 *
 * [1624] Largest Substring Between Two Equal Characters
 */

// @lc code=start
class Solution {
    public int maxLengthBetweenEqualCharacters(String s) {
        int[][] ids = new int[26][2];
        for (int i = 0; i < 26; ++i) {
            ids[i][0] = 10000;
            ids[i][1] = -10000;
        }
        int n = s.length();
        for (int i = 0; i < n; ++i) {
            int c = s.charAt(i) - 'a';
            ids[c][0] = Math.min(ids[c][0], i);
            ids[c][1] = Math.max(ids[c][1], i);
        }
        int ret = -1;
        for (int i = 0; i < 26; ++i) {
            ret = Math.max(ids[i][1] - ids[i][0] - 1, ret);
        }
        return ret;
    }
}
// @lc code=end

