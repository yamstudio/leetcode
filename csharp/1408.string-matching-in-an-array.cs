/*
 * @lc app=leetcode id=1408 lang=csharp
 *
 * [1408] String Matching in an Array
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public IList<string> StringMatching(string[] words) {
        int n = words.Length;
        var ret = new List<string>();
        Array.Sort(words, Comparer<string>.Create((a, b) => {
            return a.Length.CompareTo(b.Length);
        }));
        for (int i = 0; i < n; ++i) {
            var word = words[i];
            for (int j = i + 1; j < n; ++j) {
                if (words[j].Contains(word)) {
                    ret.Add(word);
                    break;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

