/*
 * @lc app=leetcode id=955 lang=java
 *
 * [955] Delete Columns to Make Sorted II
 */

// @lc code=start
class Solution {
    public int minDeletionSize(String[] strs) {
        int n = strs.length, m = strs[0].length(), ret = 0;
        boolean[] sorted = new boolean[n - 1];
        for (int j = 0; j < m; ++j) {
            int i = 0;
            for (; i < n - 1; ++i) {
                if (sorted[i]) {
                    continue;
                }
                if (strs[i].charAt(j) > strs[i + 1].charAt(j)) {
                    ++ret;
                    break;
                }
            }
            if (i < n - 1) {
                continue;
            }
            for (i = 0; i < n - 1; ++i) {
                sorted[i] |= strs[i].charAt(j) < strs[i + 1].charAt(j);
            }
        }
        return ret;
    }
}
// @lc code=end

