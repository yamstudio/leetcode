/*
 * @lc app=leetcode id=49 lang=csharp
 *
 * [49] Group Anagrams
 */

using System.Collections.Generic;

public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        IDictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();
        foreach (string s in strs) {
            char[] array = s.ToCharArray();
            Array.Sort(array);
            string key = new string(array);
            if (!map.ContainsKey(key)) {
                map[key] = new List<string>();
            }
            map[key].Add(s);
        }
        return new List<IList<string>>(map.Values);
    }
}

