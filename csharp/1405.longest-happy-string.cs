/*
 * @lc app=leetcode id=1405 lang=csharp
 *
 * [1405] Longest Happy String
 */

using System.Text;

// @lc code=start
public class Solution {
    public string LongestDiverseString(int a, int b, int c) {
        var ret = new StringBuilder();
        int au = 0, bu = 0, cu = 0, t = a + b + c;
        for (int i = 0; i < t; ++i) {
            if (a >= b && a >= c && au < 2 || a > 0 && (bu == 2 || cu == 2)) {
                ret.Append('a');
                --a;
                ++au;
                bu = 0;
                cu = 0;
            } else if (b >= a && b >= c && bu < 2 || b > 0 && (au == 2 || cu == 2)) {
                ret.Append('b');
                --b;
                ++bu;
                au = 0;
                cu = 0;
            } else if (c >= a && c >= b && cu < 2 || c > 0 && (au == 2 || bu == 2)) {
                ret.Append('c');
                --c;
                ++cu;
                au = 0;
                bu = 0;
            } else {
                break;
            }
        }
        return ret.ToString();
    }
}
// @lc code=end

