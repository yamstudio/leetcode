/*
 * @lc app=leetcode id=1544 lang=csharp
 *
 * [1544] Make The String Great
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {

    private const int Diff = (int)'a' - (int)'A';

    public string MakeGood(string s) {
        var list = new List<char>();
        foreach (char c in s) {
            if (list.Count == 0) {
                list.Add(c);
                continue;
            }
            char p = list[list.Count - 1];
            if (Math.Abs(c - p) == Diff) {
                list.RemoveAt(list.Count - 1);
            } else {
                list.Add(c);
            }
        }
        return new string(list.ToArray());
    }
}
// @lc code=end

