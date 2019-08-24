/*
 * @lc app=leetcode id=290 lang=csharp
 *
 * [290] Word Pattern
 */

using System.Collections.Generic;

public class Solution {
    public bool WordPattern(string pattern, string str) {
        var map = new Dictionary<string, string>();
        var split = str.Split(' ');
        int n = pattern.Length;
        if (split.Length != n) {
            return false;
        }
        for (int i = 0; i < n; ++i) {
            string p = $"${pattern[i]}", s = split[i];
            if (map.ContainsKey(p)) {
                if (map[p] != s) {
                    return false;
                }
            } else {
                if (map.ContainsKey(s)) {
                    return false;
                }
                map[p] = s;
                map[s] = p;
            }
        }
        return true;
    }
}

