/*
 * @lc app=leetcode id=1422 lang=csharp
 *
 * [1422] Maximum Score After Splitting a String
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int MaxScore(string s) {
        int n = s.Length, ones = s.Count(c => c == '1'), ret, acc;
        if (s[0] == '1') {
            acc = 1;
            ret = ones - 1;
        } else {
            acc = 0;
            ret = 1 + ones;
        }
        for (int i = 1; i < n - 1; ++i) {
            if (s[i] == '1') {
                ++acc;
            }
            ret = Math.Max(ret, ones - acc + i + 1 - acc);
        }
        return ret;
    }
}
// @lc code=end

