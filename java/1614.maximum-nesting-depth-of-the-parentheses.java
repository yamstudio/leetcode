/*
 * @lc app=leetcode id=1614 lang=java
 *
 * [1614] Maximum Nesting Depth of the Parentheses
 */

// @lc code=start
class Solution {
    public int maxDepth(String s) {
        int m = 0, a = 0, n = s.length();
        for (int i = 0; i < n; ++i) {
            char c = s.charAt(i);
            if (c == '(') {
                ++a;
                m = Math.max(m, a);
            } else if (c == ')') {
                --a;
            }
        }
        return m;
    }
}
// @lc code=end

