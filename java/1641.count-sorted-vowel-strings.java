/*
 * @lc app=leetcode id=1641 lang=java
 *
 * [1641] Count Sorted Vowel Strings
 */

// @lc code=start
class Solution {
    public int countVowelStrings(int n) {
        return countVowelStrings(0, n, new Integer[5][n]);
    }

    private static int countVowelStrings(int c, int l, Integer[][] memo) {
        if (l == 0) {
            return 1;
        }
        Integer m = memo[c][l - 1];
        if (m != null) {
            return m;
        }
        int ret = 0;
        for (int nc = c; nc < 5; ++nc) {
            ret += countVowelStrings(nc, l - 1, memo);
        }
        memo[c][l - 1] = ret;
        return ret;
    }
}
// @lc code=end

