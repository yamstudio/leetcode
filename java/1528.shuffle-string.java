/*
 * @lc app=leetcode id=1528 lang=java
 *
 * [1528] Shuffle String
 */

// @lc code=start
class Solution {
    public String restoreString(String s, int[] indices) {
        int n = s.length();
        char[] ret = new char[n];
        for (int i = 0; i < n; ++i) {
            ret[indices[i]] = s.charAt(i);
        }
        return new String(ret);
    }
}
// @lc code=end

