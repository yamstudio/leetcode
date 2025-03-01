/*
 * @lc app=leetcode id=1397 lang=java
 *
 * [1397] Find All Good Strings
 */

// @lc code=start
class Solution {
    public int findGoodStrings(int n, String s1, String s2, String evil) {
        int k = evil.length(), j = 0;
        int[] lps = new int[k];
        for (int i = 1; i < k;) {
            if (evil.charAt(j) == evil.charAt(i)) {
                lps[i++] = ++j;
            } else if (j == 0) {
                ++i;
            } else {
                j = lps[j - 1];
            }
        }
        return findGoodStrings(n, s1, s2, evil, lps, 0, 0, true, true, new int[n][k][2][2]);
    }

    private static int findGoodStrings(int n, String s1, String s2, String evil, int[] lps, int index, int lpsIndex, boolean bound1, boolean bound2, int[][][][] memo) {
        int k = lps.length;
        if (lpsIndex == k) {
            return 0;
        }
        if (index == n) {
            return 1;
        }
        int ret = memo[index][lpsIndex][bound1 ? 1 : 0][bound2 ? 1 : 0];
        if (ret != 0) {
            return ret;
        }
        char min = bound1 ? s1.charAt(index) : 'a', max = bound2 ? s2.charAt(index) : 'z';
        for (char c = min; c <= max; ++c) {
            int nextLpsIndex = lpsIndex;
            while (nextLpsIndex > 0 && c != evil.charAt(nextLpsIndex)) {
                nextLpsIndex = lps[nextLpsIndex - 1];
            }
            if (c == evil.charAt(nextLpsIndex)) {
                ++nextLpsIndex;
            } else {
                nextLpsIndex = 0;
            }
            ret += findGoodStrings(n, s1, s2, evil, lps, index + 1, nextLpsIndex, bound1 && c == s1.charAt(index), bound2 && c == s2.charAt(index), memo);
            ret = ret % 1000000007;
        }
        memo[index][lpsIndex][bound1 ? 1 : 0][bound2 ? 1 : 0] = ret;
        return ret;
    }
}
// @lc code=end

