/*
 * @lc app=leetcode id=984 lang=java
 *
 * [984] String Without AAA or BBB
 */

// @lc code=start
class Solution {
    public String strWithout3a3b(int a, int b) {
        int l, s;
        char lc, sc;
        if (a > b) {
            l = a;
            lc = 'a';
            s = b;
            sc = 'b';
        } else {
            l = b;
            lc = 'b';
            s = a;
            sc = 'a';
        }
        int g = l - s;
        StringBuilder sb = new StringBuilder(a + b);
        while (l > 0) {
            if (l > 0) {
                --l;
                sb.append(lc);
            }
            if (l > 0 && g > 0) {
                --l;
                --g;
                sb.append(lc);
            }
            if (s > 0) {
                --s;
                sb.append(sc);
            }
        }
        return sb.toString();
    }
}
// @lc code=end

