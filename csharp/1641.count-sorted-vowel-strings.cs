/*
 * @lc app=leetcode id=1641 lang=csharp
 *
 * [1641] Count Sorted Vowel Strings
 */

// @lc code=start
public class Solution {

    private static int CountVowelStrings(int n, int i, int c, int?[,] memo) {
        if (i == n) {
            return 1;
        }
        if (memo[i, c].HasValue) {
            return memo[i, c].Value;
        }
        int ret = 0;
        for (int nc = c; nc < 5; ++nc) {
            ret += CountVowelStrings(n, i + 1, nc, memo);
        }
        memo[i, c] = ret;
        return ret;
    }

    public int CountVowelStrings(int n) {
        return CountVowelStrings(n, 0, 0, new int?[n, 5]);
    }
}
// @lc code=end

