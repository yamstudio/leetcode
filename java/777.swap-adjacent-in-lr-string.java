/*
 * @lc app=leetcode id=777 lang=java
 *
 * [777] Swap Adjacent in LR String
 */

// @lc code=start
class Solution {
    public boolean canTransform(String start, String end) {
        int n = start.length(), i = 0, j = 0;
        while (i < n && j < n) {
            while (i < n && start.charAt(i) == 'X') {
                ++i;
            }
            while (j < n && end.charAt(j) == 'X') {
                ++j;
            }
            if (i == n) {
                return j == n;
            }
            if (j == n) {
                return false;
            }
            if (start.charAt(i) != end.charAt(j)) {
                return false;
            }
            if (start.charAt(i) == 'L' && j > i) {
                return false;
            }
            if (start.charAt(i) == 'R' && j < i) {
                return false;
            }
            ++i;
            ++j;
        }
        while (i < n) {
            if (start.charAt(i++) != 'X') {
                return false;
            }
        }
        while (j < n) {
            if (end.charAt(j++) != 'X') {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

