/*
 * @lc app=leetcode id=761 lang=csharp
 *
 * [761] Special Binary String
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public string MakeLargestSpecial(string S) {
        int i = 0, n = S.Length, diff = 0;
        IList<string> ret = new List<string>();
        for (int j = 0; j < n; ++j) {
            diff += S[j] == '1' ? 1 : -1;
            if (diff == 0) {
                ret.Add($"1{MakeLargestSpecial(S.Substring(i + 1, j - i - 1))}0");
                i = j + 1;
            }
        }
        return string.Concat(ret.OrderByDescending(s => s));
    }
}
// @lc code=end

