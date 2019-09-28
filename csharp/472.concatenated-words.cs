/*
 * @lc app=leetcode id=472 lang=csharp
 *
 * [472] Concatenated Words
 */

using System.Collections.Generic;

public class Solution {

    private static bool FindRecurse(ISet<string> set, string word, int i, int count) {
        int n = word.Length;
        if (i >= n && count > 1) {
            return true;
        }
        for (int j = 1; j + i <= n; ++j) {
            if (set.Contains(word.Substring(i, j)) && FindRecurse(set, word, i + j, count + 1)) {
                return true;
            }
        }
        return false;
    }

    public IList<string> FindAllConcatenatedWordsInADict(string[] words) {
        int m = words.Length;
        IList<string> ret = new List<string>();
        ISet<string> set = new HashSet<string>(m);
        SortedSet<int> lengths = new SortedSet<int>();
        foreach (string word in words) {
            int len = word.Length;
            if (len == 0) {
                continue;
            }
            set.Add(word);
            lengths.Add(len);
        }
        foreach (string word in words) {
            if (word.Length < 2 * lengths.Min) {
                continue;
            }
            if (FindRecurse(set, word, 0, 0)) {
                ret.Add(word);
            }
        }
        return ret;
    }
}

