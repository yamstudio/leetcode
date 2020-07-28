/*
 * @lc app=leetcode id=967 lang=csharp
 *
 * [967] Numbers With Same Consecutive Differences
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    private void NumsSameConsecDiffRecurse(int N, int K, int curr, int i, IList<int> ret) {
        if (i == N) {
            ret.Add(curr);
            return;
        }
        int l = curr % 10;
        if (l >= K) {
            NumsSameConsecDiffRecurse(N, K, curr * 10 + l - K, i + 1, ret);
        }
        if (l + K < 10 && K > 0) {
            NumsSameConsecDiffRecurse(N, K, curr * 10 + l + K, i + 1, ret);
        }
    }
    
    public int[] NumsSameConsecDiff(int N, int K) {
        var ret = new List<int>();
        if (N == 1) {
            return Enumerable.Range(0, 10).ToArray();
        }
        for (int i = 1; i < 10; ++i) {
            NumsSameConsecDiffRecurse(N, K, i, 1, ret);
        }
        return ret.ToArray();
    }
}
// @lc code=end

