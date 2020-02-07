/*
 * @lc app=leetcode id=821 lang=csharp
 *
 * [821] Shortest Distance to a Character
 */

using System;

// @lc code=start
public class Solution {
    public int[] ShortestToChar(string S, char C) {
        int n = S.Length, p = -1;
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            if (S[i] == C) {
                p = i;
                continue;
            }
            if (p < 0) {
                ret[i] = int.MaxValue;
            } else {
                ret[i] = i - p;
            }
        }
        p = -1;
        for (int i = n - 1; i >= 0; --i) {
            if (S[i] == C) {
                p = i;
                continue;
            }
            if (p >= 0) {
                ret[i] = Math.Min(ret[i], p - i);
            }
        }
        return ret;
    }
}
// @lc code=end

