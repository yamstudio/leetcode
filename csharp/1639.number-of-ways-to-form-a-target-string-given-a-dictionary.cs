/*
 * @lc app=leetcode id=1639 lang=csharp
 *
 * [1639] Number of Ways to Form a Target String Given a Dictionary
 */

// @lc code=start
public class Solution {

    private static int NumWays(string target, int i, int k, int m, int[,] count, int?[,] memo) {
        if (i == target.Length) {
            return 1;
        }
        if (k >= m) {
            return 0;
        }
        if (memo[i, k].HasValue) {
            return memo[i, k].Value;
        }
        int ret = NumWays(target, i, k + 1, m, count, memo), c = (int)target[i] - (int)'a',  t = count[c, k];
        if (t > 0) {
            ret = (ret + (int)((long)t * (long)NumWays(target, i + 1, k + 1, m, count, memo) % 1000000007)) % 1000000007;
        }
        memo[i, k] = ret;
        return ret;
    }

    public int NumWays(string[] words, string target) {
        int m = words[0].Length;
        int[,] count = new int[26, m];
        foreach (string word in words) {
            for (int i = 0; i < m; ++i) {
                count[(int)word[i] - (int)'a', i]++;
            }
        }
        return NumWays(target, 0, 0, m, count, new int?[target.Length, m]);
    }
}
// @lc code=end

