/*
 * @lc app=leetcode id=890 lang=csharp
 *
 * [890] Find and Replace Pattern
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static bool IsMatch(string word, string pattern) {
        var w2p = new Dictionary<char, char>();
        var ps = new HashSet<char>();
        int n = pattern.Length;
        if (n != word.Length) {
            return false;
        }
        for (int i = 0; i < n; ++i) {
            char w = word[i];
            if (w2p.TryGetValue(w, out char p)) {
                if (p != pattern[i]) {
                    return false;
                }
                continue;
            }
            if (!ps.Add(pattern[i])) {
                return false;
            }
            w2p[w] = pattern[i];
        }
        return true;
    }

    public IList<string> FindAndReplacePattern(string[] words, string pattern) {
        return words
            .Where(word => IsMatch(word, pattern))
            .ToList();
    }
}
// @lc code=end

