/*
 * @lc app=leetcode id=819 lang=csharp
 *
 * [819] Most Common Word
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public string MostCommonWord(string paragraph, string[] banned) {
        var set = new HashSet<string>(banned);
        return paragraph
            .ToLower()
            .Split(new char[] { ' ', '!', '?', '\'', ',', ';', '.' })
            .Where(word => !string.IsNullOrEmpty(word) && !set.Contains(word))
            .GroupBy(word => word)
            .Select(group => (Word: group.Key, Count: group.Count()))
            .Aggregate((acc, curr) => acc.Count < curr.Count ? curr : acc)
            .Word;
    }
}
// @lc code=end

