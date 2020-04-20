/*
 * @lc app=leetcode id=884 lang=csharp
 *
 * [884] Uncommon Words from Two Sentences
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public string[] UncommonFromSentences(string A, string B) {
        var count = new Dictionary<string, int>();
        foreach (var word in A.Split()) {
            if (count.TryGetValue(word, out var c)) {
                count[word] = c + 1;
            } else {
                count[word] = 1;
            }
        }
        foreach (var word in B.Split()) {
            if (count.TryGetValue(word, out var c)) {
                count[word] = c + 1;
            } else {
                count[word] = 1;
            }
        }
        return count.Where(tuple => tuple.Value == 1).Select(tuple => tuple.Key).ToArray();
    }
}
// @lc code=end

