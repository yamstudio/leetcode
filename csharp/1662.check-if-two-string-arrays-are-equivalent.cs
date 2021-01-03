/*
 * @lc app=leetcode id=1662 lang=csharp
 *
 * [1662] Check If Two String Arrays are Equivalent
 */

using System.Linq;

// @lc code=start
public class Solution {
    public bool ArrayStringsAreEqual(string[] word1, string[] word2) {
        return word1
            .SelectMany(w => w)
            .SequenceEqual(word2.SelectMany(w => w));
    }
}
// @lc code=end

