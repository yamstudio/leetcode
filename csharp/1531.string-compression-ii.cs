/*
 * @lc app=leetcode id=1531 lang=csharp
 *
 * [1531] String Compression II
 */

using System;

// @lc code=start
public class Solution {

    private static int GetLengthOfOptimalCompression(string s, int i, int p, int pc, int k, int?[,,,] memo) {
        if (k < 0) {
            return int.MaxValue;
        }
        if (i == s.Length) {
            return 0;
        }
        if (memo[i, p, pc, k].HasValue) {
            return memo[i, p, pc, k].Value;
        }
        int c = (int)s[i] - (int)'a', ret;
        if (c == p) {
            ret = GetLengthOfOptimalCompression(s, i + 1, p, 1 + pc, k, memo);
            if (pc == 1 || pc == 9 || pc == 99) {
                ++ret;
            }
        } else {
            int del = GetLengthOfOptimalCompression(s, i + 1, p, pc, k - 1, memo), add = 1 + GetLengthOfOptimalCompression(s, i + 1, c, 1, k, memo);
            ret = Math.Min(del, add);
        }
        memo[i, p, pc, k] = ret;
        return ret;
    }

    public int GetLengthOfOptimalCompression(string s, int k) {
        int n = s.Length;
        return GetLengthOfOptimalCompression(s, 0, 26, 0, k, new int?[n, 27, n + 1, k + 1]);
    }
}
// @lc code=end

