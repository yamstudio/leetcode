/*
 * @lc app=leetcode id=557 lang=csharp
 *
 * [557] Reverse Words in a String III
 */

using System.Linq;

// @lc code=start
public class Solution {
    public string ReverseWords(string s) {
        return string.Join(" ", s.Split(' ').Select(word => new string(word.Reverse().ToArray())));
    }
}
// @lc code=end

