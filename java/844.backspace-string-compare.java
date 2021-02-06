/*
 * @lc app=leetcode id=844 lang=java
 *
 * [844] Backspace String Compare
 */

// @lc code=start
class Solution {
    public boolean backspaceCompare(String S, String T) {
        int i = S.length() - 1, j = T.length() - 1;
        while (true) {
            int b = 0;
            while (i >= 0 && (b > 0 || S.charAt(i) == '#')) {
                if (S.charAt(i) == '#') {
                    ++b;
                } else {
                    --b;
                }
                --i;
            }
            b = 0;
            while (j >= 0 && (b > 0 || T.charAt(j) == '#')) {
                if (T.charAt(j) == '#') {
                    ++b;
                } else {
                    --b;
                }
                --j;
            }
            if (i < 0) {
                return j < 0;
            }
            if (j < 0) {
                return false;
            }
            if (S.charAt(i) != T.charAt(j)) {
                return false;
            }
            --i;
            --j;
        }
    }
}
// @lc code=end

