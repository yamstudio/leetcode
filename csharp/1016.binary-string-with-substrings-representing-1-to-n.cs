/*
 * @lc app=leetcode id=1016 lang=csharp
 *
 * [1016] Binary String With Substrings Representing 1 To N
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public bool QueryString(string S, int N) {
        if (N > 2047) {
            return false;
        }
        return Enumerable
            .Range(1 + N - (N + 1) / 2, (N + 1) / 2)
            .Select(x => Convert.ToString(x, 2))
            .All(S.Contains);
    }
}
// @lc code=end

