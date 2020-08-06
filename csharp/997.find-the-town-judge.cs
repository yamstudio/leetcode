/*
 * @lc app=leetcode id=997 lang=csharp
 *
 * [997] Find the Town Judge
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int FindJudge(int N, int[][] trust) {
        if (N == 1) {
            return 1;
        }
        if (trust.Length < N - 1) {
            return -1;
        }
        var trustedBy = new Dictionary<int, int>();
        foreach (var t in trust) {
            int truster = t[0], trustee = t[1];
            trustedBy[truster] = -1;
            if (!trustedBy.TryGetValue(trustee, out var c)) {
                trustedBy[trustee] = 1;
            } else {
                if (c > 0) {
                    trustedBy[trustee] = c + 1;
                }
            }
        }
        int ret = -1;
        foreach (var tuple in trustedBy) {
            if (tuple.Value == N - 1) {
                if (ret != -1) {
                    return -1;
                }
                ret = tuple.Key;
            }
        }
        return ret;
    }
}
// @lc code=end

