/*
 * @lc app=leetcode id=1208 lang=java
 *
 * [1208] Get Equal Substrings Within Budget
 */

// @lc code=start
class Solution {
    public int equalSubstring(String s, String t, int maxCost) {
        int n = s.length(), cost = 0, l = 0, ret = 0;
        for (int r = 0; r < n; ++r) {
            cost += Math.abs(s.charAt(r) - t.charAt(r));
            while (cost > maxCost) {
                cost -= Math.abs(s.charAt(l) - t.charAt(l));
                ++l;
            }
            ret = Math.max(ret, r - l + 1);
        }
        return ret;
    }
}
// @lc code=end

