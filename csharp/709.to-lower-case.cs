/*
 * @lc app=leetcode id=709 lang=csharp
 *
 * [709] To Lower Case
 */

using System.Linq;

// @lc code=start
public class Solution {
    public string ToLowerCase(string str) {
        return new string(str.Select(c => (c >= 'A' && c <= 'Z') ? ((char) ((int) c - (int) 'A' + (int) 'a')) : c).ToArray());
    }
}
// @lc code=end

