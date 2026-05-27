/*
 * @lc app=leetcode id=1745 lang=java
 *
 * [1745] Palindrome Partitioning IV
 */

// @lc code=start
class Solution {
    public boolean checkPartitioning(String s) {
        int n = s.length();
        boolean[][] pal = new boolean[n][n];
        for (int i = n - 1; i >= 0; --i) {
            char ci = s.charAt(i);
            for (int j = i; j < n; ++j) {
                char cj = s.charAt(j);
                pal[i][j] = ci == cj && (i + 1 >= j - 1 || pal[i + 1][j - 1]);
            }
        }
        for (int i = 1; i < n - 1; ++i) {
            for (int j = i; j < n - 1; ++j) {
                if (pal[0][i - 1] && pal[i][j] && pal[j + 1][n - 1]) {
                    return true;
                }
            }
        }
        return false;
    }
}
// @lc code=end

