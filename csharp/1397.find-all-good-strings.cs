/*
 * @lc app=leetcode id=1397 lang=csharp
 *
 * [1397] Find All Good Strings
 */

// @lc code=start
public class Solution {

    private static int FindGoodStrings(int n, int k, string s1, string s2, string evil, int[] lps, int[,,,] dp, int si, int ei, int bound1, int bound2) {
        if (ei == k) {
            return 0;
        }
        if (si == n) {
            return 1;
        }
        if (dp[si, ei, bound1, bound2] != 0) {
            return dp[si, ei, bound1, bound2];
        }
        int ret = 0;
        char minC = bound1 == 1 ? s1[si] : 'a', maxC = bound2 == 1 ? s2[si] : 'z';
        for (char c = minC; c <= maxC; ++c) {
            int nei = ei;
            while (nei > 0 && c != evil[nei]) {
                nei = lps[nei - 1];
            }
            if (c == evil[nei]) {
                nei++;
            } else {
                nei = 0;
            }
            int nbound1 = bound1 == 1 && s1[si] == c ? 1 : 0, nbound2 = bound2 == 1 && s2[si] == c ? 1 : 0;
            ret += FindGoodStrings(n, k, s1, s2, evil, lps, dp, si + 1, nei, nbound1, nbound2);
            ret %= 1000000007;
        }
        return dp[si, ei, bound1, bound2] = ret;
    }

    public int FindGoodStrings(int n, string s1, string s2, string evil) {
        int k = evil.Length, j = 0;
        var lps = new int[k];
        for (int i = 1; i < k;) {
            if (evil[i] == evil[j]) {
                lps[i++] = ++j;
            } else {
                if (j == 0) {
                    ++i;
                } else {
                    j = lps[j - 1];
                }
            }
        }
        return FindGoodStrings(n, k, s1, s2, evil, lps, new int[n, k, 2, 2], 0, 0, 1, 1);
    }
}
// @lc code=end

