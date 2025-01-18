/*
 * @lc app=leetcode id=1247 lang=java
 *
 * [1247] Minimum Swaps to Make Strings Equal
 */

// @lc code=start
class Solution {
    public int minimumSwap(String s1, String s2) {
        int n = s1.length(), xy = 0, yx = 0;
        for (int i = 0; i < n; ++i) {
            char c1 = s1.charAt(i), c2 = s2.charAt(i);
            if (c1 == 'x' && c2 == 'y') {
                ++xy;
            } else if (c1 == 'y' && c2 == 'x') {
                ++yx;
            }
        }
        if (xy % 2 != yx % 2) {
            return -1;
        }
        return xy / 2 + yx / 2 + 2 * (xy % 2);
    }
}
// @lc code=end

