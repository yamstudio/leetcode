/*
 * @lc app=leetcode id=1312 lang=java
 *
 * [1312] Minimum Insertion Steps to Make a String Palindrome
 */

// @lc code=start
class Solution {
    public int minInsertions(String s) {
        int n = s.length();
        return minInsertionsRecurse(s, 0, n - 1, new int[n][n]) - 1;
    }

    private static int minInsertionsRecurse(String s, int l, int r, int[][] memo) {
        if (l >= r) {
            return 1;
        }
        if (memo[l][r] != 0) {
            return memo[l][r];
        }
        if (s.charAt(l) == s.charAt(r)) {
            memo[l][r] = minInsertionsRecurse(s, l + 1, r - 1, memo);
        } else {
            memo[l][r] = 1 + Math.min(minInsertionsRecurse(s, l + 1, r, memo), minInsertionsRecurse(s, l, r - 1, memo));
        }
        return memo[l][r];
    }
}
// @lc code=end

