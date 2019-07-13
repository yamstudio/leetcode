/*
 * @lc app=leetcode id=76 lang=csharp
 *
 * [76] Minimum Window Substring
 */

using System.Collections.Generic;

public static class Ext {
    public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
    {
        TValue value;
        return dictionary.TryGetValue(key, out value) ? value : defaultValue;
    }
}
public class Solution {
    public string MinWindow(string s, string t) {
        if (s.Length == 0 || t.Length == 0) {
            return "";
        }
        IDictionary<char, int> pattern = new Dictionary<char, int>(), curr = new Dictionary<char, int>();
        int total = 0, count = 0, left = 0;
        string ret = "";
        foreach (char c in t) {
            pattern[c] = pattern.GetOrDefault(c, 0) + 1;
            ++total;
        }
        for (int i = 0; i < s.Length; ++i) {
            char c = s[i];
            if (!pattern.ContainsKey(c)) {
                continue;
            }
            curr[c] = curr.GetOrDefault(c, 0) + 1;
            if (curr[c] <= pattern[c]) {
                ++count;
            }
            if (total == count) {
                while (left <= i) {
                    char l = s[left];
                    if (pattern.ContainsKey(l)) {
                        if (pattern[l] == curr[l]) {
                            break;
                        }
                        curr[l]--;
                    }
                    ++left;
                }
                if (ret == "" || i - left + 1 < ret.Length) {
                    ret = s.Substring(left, i - left + 1);
                }
            }
        }
        return ret;
    }
}

