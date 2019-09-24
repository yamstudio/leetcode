/*
 * @lc app=leetcode id=451 lang=csharp
 *
 * [451] Sort Characters By Frequency
 */

using System.Collections.Generic;
using System.Linq;

public class Solution {
    public string FrequencySort(string s) {
        IDictionary<char, int> count = new Dictionary<char, int>();
        foreach (char c in s) {
            count[c] = 1 + (count.ContainsKey(c) ? count[c] : 0);
        }
        return new string(s.OrderByDescending(c => (count[c], c)).ToArray());
    }
}

