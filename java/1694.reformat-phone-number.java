/*
 * @lc app=leetcode id=1694 lang=java
 *
 * [1694] Reformat Phone Number
 */

// @lc code=start
class Solution {
    public String reformatNumber(String number) {
        int n = number.length(), k = 0;
        for (int i = 0; i < n; ++i) {
            char c = number.charAt(i);
            if (c >= '0' && c <= '9') {
                ++k;
            }
        }
        StringBuilder sb = new StringBuilder(k + k / 3 + 1);
        int r = k, i;
        for (i = 0; i < n && (k % 3 != 1 || r > 4); ++i) {
            char c = number.charAt(i);
            if (c >= '0' && c <= '9') {
                if (r != k && (k - r) % 3 == 0) {
                    sb.append('-');
                }
                sb.append(c);
                --r;
            }
        }
        if (r > 0) {
            if (r != k) {
                sb.append('-');
            }
            for (; i < n; ++i) {
                char c = number.charAt(i);
                if (c >= '0' && c <= '9') {
                    sb.append(c);
                    --r;
                    if (r == 2) {
                        sb.append('-');
                    }
                }
            }
        }
        return sb.toString();
    }
}
// @lc code=end

