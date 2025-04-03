/*
 * @lc app=leetcode id=1531 lang=java
 *
 * [1531] String Compression II
 */

// @lc code=start
class Solution {
    public int getLengthOfOptimalCompression(String s, int k) {
        int n = s.length();
        return getLengthOfOptimalCompression(s, 0, 26, 0, k, new Integer[n][27][n + 1][k + 1]);
    }

    private static int getLengthOfOptimalCompression(String s, int i, int prevChar, int prevCount, int k, Integer[][][][] memo) {
        if (k < 0) {
            return Integer.MAX_VALUE;
        }
        int n = s.length();
        if (i == n) {
            return 0;
        }
        Integer m = memo[i][prevChar][prevCount][k];
        if (m != null) {
            return m;
        }
        int ret, c = s.charAt(i) - 'a';
        if (c == prevChar) {
            ret = getLengthOfOptimalCompression(s, i + 1, prevChar, prevCount + 1, k, memo);
            if (prevCount == 1 || prevCount == 9 || prevCount == 99) {
                ++ret;
            }
        } else {
            int del = getLengthOfOptimalCompression(s, i + 1, prevChar, prevCount, k - 1, memo), keep = getLengthOfOptimalCompression(s, i + 1, c, 1, k, memo) + 1;
            ret = Math.min(del, keep);
        }
        memo[i][prevChar][prevCount][k] = ret;
        return ret;
    }
}
// @lc code=end

