/*
 * @lc app=leetcode id=944 lang=java
 *
 * [944] Delete Columns to Make Sorted
 */

// @lc code=start
class Solution {
    public int minDeletionSize(String[] strs) {
        char[] sorted = null;
        for (String curr : strs) {
            if (sorted == null) {
                sorted = curr.toCharArray();
                continue;
            }
            for (int i = 0; i < curr.length(); ++i) {
                if (sorted[i] == '\0') {
                    continue;
                }
                char c = curr.charAt(i);
                if (c < sorted[i]) {
                    sorted[i] = '\0';
                } else {
                    sorted[i] = c;
                }
            }
        }
        int ret = 0;
        for (int i = 0; i < sorted.length; ++i) {
            if (sorted[i] == '\0') {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

