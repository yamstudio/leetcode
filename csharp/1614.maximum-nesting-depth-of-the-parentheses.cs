/*
 * @lc app=leetcode id=1614 lang=csharp
 *
 * [1614] Maximum Nesting Depth of the Parentheses
 */

// @lc code=start
public class Solution {
    public int MaxDepth(string s) {
        int ret = 0, d = 0;
        foreach (char c in s) {
            if (c == '(') {
                if (++d > ret) {
                    ret = d;
                }
            } else if (c == ')') {
                --d;
            }
        }
        return ret;
    }
}
// @lc code=end

