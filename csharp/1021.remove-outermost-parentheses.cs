/*
 * @lc app=leetcode id=1021 lang=csharp
 *
 * [1021] Remove Outermost Parentheses
 */

using System.Text;

// @lc code=start
public class Solution {
    public string RemoveOuterParentheses(string S) {
        var sb = new StringBuilder();
        int l = 0;
        foreach (char c in S) {
            if (c == '(') {
                ++l;
                if (l > 1) {
                    sb.Append(c);
                }
            } else {
                --l;
                if (l > 0) {
                    sb.Append(c);
                }
            }
        }
        return sb.ToString();
    }
}
// @lc code=end

