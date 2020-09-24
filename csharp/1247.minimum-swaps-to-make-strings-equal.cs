/*
 * @lc app=leetcode id=1247 lang=csharp
 *
 * [1247] Minimum Swaps to Make Strings Equal
 */

// @lc code=start
public class Solution {
    public int MinimumSwap(string s1, string s2) {
        int n = s1.Length, ret = 0, xy = 0, yx = 0;
        for (int i = 0; i < n; ++i) {
            char c1 = s1[i], c2 = s2[i];
            if (c1 == 'x' && c2 == 'y') {
                ++xy;
            } else if (c1 == 'y' && c2 == 'x') {
                ++yx;
            }
        }
        ret += xy / 2 + yx / 2;
        xy %= 2;
        yx %= 2;
        if (xy != yx) {
            return -1;
        }
        return ret + 2 * xy;
    }
}
// @lc code=end

