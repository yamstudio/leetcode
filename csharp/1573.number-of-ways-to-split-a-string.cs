/*
 * @lc app=leetcode id=1573 lang=csharp
 *
 * [1573] Number of Ways to Split a String
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int NumWays(string s) {
        int ones = s.Count(c => c == '1'), n = s.Length;
        if (ones % 3 != 0) {
            return 0;
        }
        if (ones == 0) {
            return (int)((long)(n - 2) * (long)(n - 1) / 2 % 1000000007);
        }
        int i = 0, g1 = 1, g2 = 1, acc = 0;
        while (acc < ones / 3) {
            if (s[i++] == '1') {
                ++acc;
            }
        }
        while (s[i++] != '1') {
            ++g1;
        }
        ++acc;
        while (acc < ones / 3 * 2) {
            if (s[i++] == '1') {
                ++acc;
            }
        }
        while (s[i++] != '1') {
            ++g2;
        }
        return (int)((long)g1 * (long)g2 % 1000000007);
    }
}
// @lc code=end

