/*
 * @lc app=leetcode id=1653 lang=csharp
 *
 * [1653] Minimum Deletions to Make String Balanced
 */

using System;

// @lc code=start
public class Solution {
    public int MinimumDeletions(string s) {
        int n = s.Length, aCount = 0, acc = 0, ret;
        foreach (char c in s) {
            if (c == 'a') {
                ++aCount;
            }
        }
        ret = aCount;
        for (int i = 0; i < n; ++i) {
            if (s[i] == 'a') {
                ++acc;
            }
            ret = Math.Min(ret, i + 1 - acc + aCount - acc);
        }
        return ret;
    }
}
// @lc code=end

