/*
 * @lc app=leetcode id=318 lang=csharp
 *
 * [318] Maximum Product of Word Lengths
 */

using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int MaxProduct(string[] words) {
        IDictionary<int, int> len = new Dictionary<int, int>();
        int ret = 0;
        foreach (var item in words.Select(word => (word.Aggregate(0, (m, c) => m | (1 << (int) (c - 'a'))), word.Length))) {
            int k = item.Item1, l = item.Item2;
            ret = Math.Max(ret, l * len.Where(entry => (entry.Key & k) == 0).DefaultIfEmpty().Max(entry => entry.Value));
            len[k] = len.ContainsKey(k) ? Math.Max(l, len[k]) : l;
        }
        return ret;
    }
}

