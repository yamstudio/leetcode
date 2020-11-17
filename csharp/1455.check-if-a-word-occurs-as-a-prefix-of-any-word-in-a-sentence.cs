/*
 * @lc app=leetcode id=1455 lang=csharp
 *
 * [1455] Check If a Word Occurs As a Prefix of Any Word in a Sentence
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int IsPrefixOfWord(string sentence, string searchWord) {
        return sentence
            .Split(' ')
            .Select((w, i) => (Word: w, Index: i + 1))
            .Append((Word: searchWord, Index: -1))
            .Where(t => t.Word.StartsWith(searchWord))
            .First().Index;
    }
}
// @lc code=end

