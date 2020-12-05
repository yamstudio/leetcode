/*
 * @lc app=leetcode id=1529 lang=csharp
 *
 * [1529] Bulb Switcher IV
 */

// @lc code=start
public class Solution {
    public int MinFlips(string target) {
        int ret = 0;
        char state = '0';
        foreach (char t in target) {
            if (t == state) {
                continue;
            }
            ++ret;
            state = t;
        }
        return ret;
    }
}
// @lc code=end

