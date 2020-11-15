/*
 * @lc app=leetcode id=1451 lang=csharp
 *
 * [1451] Rearrange Words in a Sentence
 */

using System.Linq;

// @lc code=start
public class Solution {
    public string ArrangeWords(string text) {
        return string.Join(' ', text
            .Split(' ')
            .Select((w, i) => (Word: w, Index: i))
            .OrderBy(t => t.Word.Length)
            .ThenBy(t => t.Index)
            .Select((t, i) => i == 0 ? $"{char.ToUpper(t.Word[0])}{t.Word.Substring(1)}" : t.Word.ToLower())
        );
    }
}
// @lc code=end

