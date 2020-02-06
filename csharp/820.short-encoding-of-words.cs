/*
 * @lc app=leetcode id=820 lang=csharp
 *
 * [820] Short Encoding of Words
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int MinimumLengthEncoding(string[] words) {
        var set = new HashSet<string>(words);
        var remove = new HashSet<string>(
            set.SelectMany(word => Enumerable.Range(1, word.Length - 1).Select(i => word.Substring(i))).Where(set.Contains)
        );
        return set.Where(word => !remove.Contains(word)).Select(word => word.Length + 1).Sum();
    }
}
// @lc code=end

