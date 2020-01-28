/*
 * @lc app=leetcode id=791 lang=csharp
 *
 * [791] Custom Sort String
 */

// @lc code=start
public class Solution {
    public string CustomSortString(string S, string T) {
        int n = S.Length, m = T.Length, t = m - 1;
        int[] map = new int[26], count = new int[n + 1];
        char[] ret = new char[m];
        for (int i = 0; i < n; ++i) {
            int x = (int)S[i] - (int)'a';
            map[x] = i + 1;
        }
        for (int i = 0; i < m; ++i) {
            char c = T[i];
            int j = map[(int)c - (int)'a'];
            if (j == 0) {
                ret[t--] = c;
            } else {
                count[j]++;
            }
        }
        t = 0;
        for (int j = 1; j <= n; ++j) {
            char c = S[j - 1];
            for (int i = 0; i < count[j]; ++i) {
                ret[t++] = c;
            }
        }
        return new string(ret);
    }
}
// @lc code=end

