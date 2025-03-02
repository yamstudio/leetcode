/*
 * @lc app=leetcode id=1405 lang=java
 *
 * [1405] Longest Happy String
 */

// @lc code=start
class Solution {
    public String longestDiverseString(int a, int b, int c) {
        StringBuilder sb = new StringBuilder();
        int aAcc = 0, bAcc = 0, cAcc = 0;
        while (a > 0 || b > 0 || c > 0) {
            if ((a > 0 && (bAcc == 2 || cAcc == 2)) || (a >= b && a >= c && aAcc < 2)) {
                sb.append('a');
                --a;
                ++aAcc;
                bAcc = 0;
                cAcc = 0;
            } else if ((b > 0 && (aAcc == 2 || cAcc == 2)) || (b >= a && b >= c && bAcc < 2)) {
                sb.append('b');
                --b;
                aAcc = 0;
                ++bAcc;
                cAcc = 0;
            } else if ((c > 0 && (aAcc == 2 || bAcc == 2)) || (c >= a && c >= b && cAcc < 2)) {
                sb.append('c');
                --c;
                aAcc = 0;
                bAcc = 0;
                ++cAcc;
            } else {
                break;
            }
        }
        return sb.toString();
    }
}
// @lc code=end

