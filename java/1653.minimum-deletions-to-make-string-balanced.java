/*
 * @lc app=leetcode id=1653 lang=java
 *
 * [1653] Minimum Deletions to Make String Balanced
 */

// @lc code=start
class Solution {
    public int minimumDeletions(String s) {
        int as = 0, n = s.length();
        for (int i = 0; i < n; ++i) {
            if (s.charAt(i) == 'a') {
                ++as;
            }
        }
        int ret = as, las = 0;
        for (int i = 0; i < n; ++i) {
            if (s.charAt(i) == 'a') {
                ++las;
            }
            ret = Math.min(ret, i + 1 - las + (as - las));
        }
        return ret;
    }
}
// @lc code=end

