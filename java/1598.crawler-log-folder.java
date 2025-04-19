/*
 * @lc app=leetcode id=1598 lang=java
 *
 * [1598] Crawler Log Folder
 */

// @lc code=start
class Solution {
    public int minOperations(String[] logs) {
        int ret = 0;
        for (String s : logs) {
            if ("../".equals(s)) {
                ret = Math.max(0, ret - 1);
            } else if (!"./".equals(s)) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

