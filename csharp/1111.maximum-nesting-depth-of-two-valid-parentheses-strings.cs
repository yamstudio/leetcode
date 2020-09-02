/*
 * @lc app=leetcode id=1111 lang=csharp
 *
 * [1111] Maximum Nesting Depth of Two Valid Parentheses Strings
 */

// @lc code=start
public class Solution {
    public int[] MaxDepthAfterSplit(string seq) {
        int n = seq.Length, stack = 0;
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            if (seq[i] == '(') {
                ret[i] = ++stack % 2;
            } else {
                ret[i] = stack-- % 2;
            }
        }
        return ret;
    }
}
// @lc code=end

