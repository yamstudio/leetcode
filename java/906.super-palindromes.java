/*
 * @lc app=leetcode id=906 lang=java
 *
 * [906] Super Palindromes
 */

// @lc code=start
class Solution {

    private static boolean isValid(long val, long l, long r) {
        if (val < l || val > r) {
            return false;
        }
        String s = Long.toString(val);
        int n = s.length();
        for (int i = n / 2; i >= 0; --i) {
            if (s.charAt(i) != s.charAt(n - 1 - i)) {
                return false;
            }
        }
        return true;
    }

    public int superpalindromesInRange(String left, String right) {
        long l = Long.parseLong(left), r = Long.parseLong(right);
        int ret = 0;
        if (l <= 1 && 1 <= r) {
            ++ret;
        }
        if (l <= 4 && 4 <= r) {
            ++ret;
        }
        if (l <= 9 && 9 <= r) {
            ++ret;
        }
        for (int i = 1; i < 10000; ++i) {
            String s = new StringBuilder(Integer.toString(i)).reverse().toString();
            Long t = Long.parseLong(String.format("%d%s", i, s));
            if (t * t > r) {
                break;
            }
            if (isValid(t * t, l, r)) {
                ++ret;
            }
            for (int m = 0; m <= 9; ++m) {
                long v = Long.parseLong(String.format("%d%d%s", i, m, s));
                if (isValid(v * v, l, r)) {
                    ++ret;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

