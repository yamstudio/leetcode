/*
 * @lc app=leetcode id=953 lang=csharp
 *
 * [953] Verifying an Alien Dictionary
 */

using System.Linq;

// @lc code=start
public class Solution {
    public bool IsAlienSorted(string[] words, string order) {
        var alphabet = order
            .Select((char c, int i) => (Letter: c, Index: (char)(i + (int)'a')))
            .ToDictionary(tuple => tuple.Letter, tuple => tuple.Index);
        words = words
            .Select(word => new string(word.Select(c => alphabet[c]).ToArray()))
            .ToArray();
        return words
            .Zip(words.Skip(1), (string prev, string next) => prev.CompareTo(next))
            .All(v => v <= 0);
    }
}
// @lc code=end

