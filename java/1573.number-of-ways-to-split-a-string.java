/*
 * @lc app=leetcode id=1573 lang=java
 *
 * [1573] Number of Ways to Split a String
 */

// @lc code=start
class Solution {
    public int numWays(String s) {
        int n = s.length(), k = 0;
        for (int i = 0; i < n; ++i) {
            k += s.charAt(i) - '0';
        }
        if (k == 0) {
            return (int)(((long)(n - 2) * (long)(n - 1) / 2) % 1000000007);
        }
        if (k % 3 != 0) {
            return 0;
        }
        int i, j, acc = 0;
        for (i = 0; i < n && acc < k / 3; ++i) {
            acc += s.charAt(i) - '0';
        }
        for (j = i; acc == k / 3; ++j) {
            acc += s.charAt(j) - '0';
        }
        int g1 = j - i;
        for (i = j; acc < k / 3 * 2; ++i) {
            acc += s.charAt(i) - '0';
        }
        for (j = i; acc == k / 3 * 2; ++j) {
            acc += s.charAt(j) - '0';
        }
        return (int)(((long)g1 * (long)(j - i)) % 1000000007);
    }
}
// @lc code=end

