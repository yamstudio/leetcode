/*
 * @lc app=leetcode id=140 lang=csharp
 *
 * [140] Word Break II
 */

using System.Collections.Generic;
using System.Linq;

public class Solution {

    private IList<string> WordBreakRecurse(string s, IList<string> wordDict, Dictionary<string, IList<string>> map) {
        if (map.ContainsKey(s)) {
            return map[s];
        }
        int n = s.Length;
        IList<string> ret = new List<string>();
        string[] subs = new string[n];
        foreach (string word in wordDict.Where(w => w.Length <= n)) {
            int l = word.Length;
            string sub;
            if (subs[l - 1] == null) {
                sub = s.Substring(0, l);
                subs[l - 1] = sub;
            } else {
                sub = subs[l - 1];
            }
            if (sub != word) {
                continue;
            }
            foreach (string str in WordBreakRecurse(s.Substring(l), wordDict, map)) {
                if (str.Length == 0) {
                    ret.Add(sub);
                } else {
                    ret.Add(sub + " " + str);
                }
            }
        }
        map[s] = ret;
        return ret;
    }

    public IList<string> WordBreak(string s, IList<string> wordDict) {
        var map = new Dictionary<string, IList<string>>();
        map[""] = new List<string>(new string[] { "" });
        return WordBreakRecurse(s, wordDict, map);
    }
}

