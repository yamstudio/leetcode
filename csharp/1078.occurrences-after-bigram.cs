/*
 * @lc app=leetcode id=1078 lang=csharp
 *
 * [1078] Occurrences After Bigram
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public string[] FindOcurrences(string text, string first, string second) {
        var split = text.Split(' ');
        int n = split.Length;
        var ret = new List<string>();
        for (int i = 0; i + 2 < n; ++i) {
            if (split[i] == first && split[i + 1] == second) {
                ret.Add(split[i + 2]);
            }
        }
        return ret.ToArray();
    }
}
// @lc code=end

