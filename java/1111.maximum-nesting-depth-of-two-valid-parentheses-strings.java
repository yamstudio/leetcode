/*
 * @lc app=leetcode id=1111 lang=java
 *
 * [1111] Maximum Nesting Depth of Two Valid Parentheses Strings
 */

// @lc code=start
class Solution {
    public int[] maxDepthAfterSplit(String seq) {
        int n = seq.length(), g = 0;
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            if (seq.charAt(i) == '(') {
                g = 1 - g;
                ret[i] = g;
            } else {
                ret[i] = g;
                g = 1 - g;
            }
        }
        return ret;
    }
}
// @lc code=end

