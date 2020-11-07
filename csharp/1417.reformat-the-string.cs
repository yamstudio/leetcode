/*
 * @lc app=leetcode id=1417 lang=csharp
 *
 * [1417] Reformat The String
 */

using System.Linq;

// @lc code=start
public class Solution {
    public string Reformat(string s) {
        int n = s.Length, k = n / 2;
        if (n == 1) {
            return s;
        }
        var split = s
            .GroupBy(c => c >= '0' && c <= '9', (i, a) => a.ToArray())
            .OrderBy(a => a.Length)
            .ToArray();
        if (split.Length != 2 || split[0].Length != k) {
            return "";
        }
        char[] ret = new char[n];
        for (int i = 0; i < k; ++i) {
            ret[2 * i] = split[1][i];
            ret[2 * i + 1] = split[0][i];
        }
        if (n % 2 == 1) {
            ret[n - 1] = split[1][k];
        }
        return new string(ret);
    }
}
// @lc code=end

