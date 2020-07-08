/*
 * @lc app=leetcode id=916 lang=csharp
 *
 * [916] Word Subsets
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static IDictionary<int, int> GetLetters(string word) {
        return word
            .GroupBy(
                c => c, 
                (char c, IEnumerable<char> all) => (Key: (int)c - (int)'a', Value: all.Count())
            )
            .ToDictionary(
                tuple => tuple.Key,
                tuple => tuple.Value
            );
    }

    public IList<string> WordSubsets(string[] A, string[] B) {
        var bLetters = B.Select(word => GetLetters(word)).ToArray();
        var letters = Enumerable
            .Range(0, 26)
            .Select(key => (Key: key, Value: bLetters.Select(l => l.TryGetValue(key, out var count) ? count : 0).DefaultIfEmpty().Max()))
            .ToDictionary(
                tuple => tuple.Key,
                tuple => tuple.Value
            );
        return A
            .Select(word => (Word: word, Letters: GetLetters(word)))
            .Where(tuple => letters.All(letter => letter.Value == 0 || (tuple.Letters.TryGetValue(letter.Key, out var count) && count >= letter.Value)))
            .Select(tuple => tuple.Word)
            .ToArray();
    }
}
// @lc code=end

