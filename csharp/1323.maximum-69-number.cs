/*
 * @lc app=leetcode id=1323 lang=csharp
 *
 * [1323] Maximum 69 Number
 */

// @lc code=start
public class Solution {
    public int Maximum69Number (int num) {
        int si = -1, t = num, i = 0;
        while (t > 0) {
            if (t % 10 == 6) {
                si = i;
            }
            t /= 10;
            ++i;
        }
        if (si < 0) {
            return num;
        }
        int sd = 3;
        while (si-- > 0) {
            sd *= 10;
        }
        return num + sd;
    }
}
// @lc code=end

