/*
 * @lc app=leetcode id=187 lang=csharp
 *
 * [187] Repeated DNA Sequences
 */

using System.Collections.Generic;
using System;

public class Solution {
    public IList<string> FindRepeatedDnaSequences(string s) {
        if (s.Length < 10) {
            return Array.Empty<string>();
        }
        IDictionary<char, int> map = new Dictionary<char, int>(4);
        map['A'] = 0;
        map['C'] = 1;
        map['G'] = 2;
        map['T'] = 3;
        ISet<string> ret = new HashSet<string>();
        ISet<int> prevs = new HashSet<int>();
        int curr = 0;
        for (int i = 0; i < 10; ++i) {
            curr = curr << 2 | map[s[i]];
        }
        prevs.Add(curr);
        for (int i = 10; i < s.Length; ++i) {
            curr = ((curr & 0x3ffff) << 2) | map[s[i]];
            if (prevs.Contains(curr)) {
                ret.Add(s.Substring(i - 9, 10));
            } else {
                prevs.Add(curr);
            }
        }
        return new List<string>(ret);
    }
}

