/*
 * @lc app=leetcode id=806 lang=java
 *
 * [806] Number of Lines To Write String
 */

// @lc code=start
class Solution {
    public int[] numberOfLines(int[] widths, String s) {
        int acc = 0, lines = 0;
        for (int i = 0; i < s.length(); ++i) {
            int w = widths[(int)s.charAt(i) - (int)'a'];
            if (acc + w > 100) {
                ++lines;
                acc = w;
            } else {
                acc += w;
            }
        }
        return new int[] { lines + 1, acc };
    }
}
// @lc code=end

