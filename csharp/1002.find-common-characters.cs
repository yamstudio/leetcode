/*
 * @lc app=leetcode id=1002 lang=csharp
 *
 * [1002] Find Common Characters
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<string> CommonChars(string[] A) {
        return A
            .SelectMany(s => s
                .GroupBy(c => c, (char key, IEnumerable<char> all) => (Key: key, Count: all.Count())))
            .GroupBy(t => t.Key, (char key, IEnumerable<(char Key, int Count)> all) => all)
            .Where(g => g.Count() == A.Length)
            .Select(g => g.Min())
            .SelectMany(g => Enumerable.Repeat($"{g.Key}", g.Count))
            .ToList();
    }
}
// @lc code=end

