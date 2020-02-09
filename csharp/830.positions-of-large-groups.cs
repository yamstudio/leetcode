/*
 * @lc app=leetcode id=830 lang=csharp
 *
 * [830] Positions of Large Groups
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public IList<IList<int>> LargeGroupPositions(string S) {
        var ret = new List<IList<int>>();
        int n = S.Length, p = 0;
        for (int i = 0; i <= n; ++i) {
            if (i != n && S[i] == S[p]) {
                continue;
            }
            if (i - p >= 3) {
                ret.Add(new List<int>() { p, i - 1 });
            }
            p = i;
        }
        return ret;
    }
}
// @lc code=end

