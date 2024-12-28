/*
 * @lc app=leetcode id=1138 lang=java
 *
 * [1138] Alphabet Board Path
 */

// @lc code=start
class Solution {
    public String alphabetBoardPath(String target) {
        StringBuilder sb = new StringBuilder();
        int n = target.length(), x = 0, y = 0;
        for (int si = 0; si < n; ++si) {
            int c = target.charAt(si) - 'a', nx = c / 5, ny = c % 5, dx = nx - x, dy = ny - y;
            boolean xFirst = x == 5;
            if (xFirst) {
                for (int i = 0; i < dx; ++i) {
                    sb.append('D');
                }
                for (int i = 0; i > dx; --i) {
                    sb.append('U');
                }
            }
            for (int i = 0; i < dy; ++i) {
                sb.append('R');
            }
            for (int i = 0; i > dy; --i) {
                sb.append('L');
            }
            if (!xFirst) {
                for (int i = 0; i < dx; ++i) {
                    sb.append('D');
                }
                for (int i = 0; i > dx; --i) {
                    sb.append('U');
                }
            }
            sb.append('!');
            x = nx;
            y = ny;
        }
        return sb.toString();
    }
}
// @lc code=end

