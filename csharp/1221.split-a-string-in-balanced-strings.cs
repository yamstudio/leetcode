/*
 * @lc app=leetcode id=1221 lang=csharp
 *
 * [1221] Split a String in Balanced Strings
 */

// @lc code=start
public class Solution {
    public int BalancedStringSplit(string s) {
        int acc = 0, ret = 0;
        foreach (var c in s) {
            if (c == 'L') {
                --acc;
            } else {
                ++acc;
            }
            if (acc == 0) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

