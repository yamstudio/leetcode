/*
 * @lc app=leetcode id=205 lang=csharp
 *
 * [205] Isomorphic Strings
 */

using System.Collections.Generic;

public class Solution {
    public bool IsIsomorphic(string s, string t) {
        var map = new Dictionary<char, char>();
        var set = new HashSet<char>();
        for (int i = 0; i < s.Length; ++i) {
            char c = s[i], k = t[i];
            if (map.ContainsKey(c)) {
                if (map[c] != k ) {
                    return false;
                }
            } else {
                if (set.Contains(k)) {
                    return false;
                }
                set.Add(k);
                map[c] = k;
            }
        }
        return true;
    }
}

