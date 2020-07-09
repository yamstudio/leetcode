/*
 * @lc app=leetcode id=921 lang=csharp
 *
 * [921] Minimum Add to Make Parentheses Valid
 */

// @lc code=start
public class Solution {
    public int MinAddToMakeValid(string S) {
        int l = 0, r = 0;
        foreach (char c in S) {
            if (c == '(') {
                ++l;
            } else {
                if (l > 0) {
                    --l;
                } else {
                    ++r;
                }
            }
        }
        return l + r;
    }
}
// @lc code=end

