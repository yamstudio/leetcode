/*
 * @lc app=leetcode id=1189 lang=java
 *
 * [1189] Maximum Number of Balloons
 */

// @lc code=start
class Solution {
    public int maxNumberOfBalloons(String text) {
        int b = 0, a = 0, l = 0, o = 0, n = 0, len = text.length();
        for (int i = 0; i < len; ++i) {
            switch (text.charAt(i)) {
                case 'b' -> ++b;
                case 'a' -> ++a;
                case 'l' -> ++l;
                case 'o' -> ++o;
                case 'n' -> ++n;
                default -> {}
            }
        }
        return Math.min(b, Math.min(a, Math.min(Math.min(l, o) / 2, n)));
    }
}
// @lc code=end

