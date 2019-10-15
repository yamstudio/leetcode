/*
 * @lc app=leetcode id=521 lang=csharp
 *
 * [521] Longest Uncommon Subsequence I 
 */

// @lc code=start
public class Solution {
    public int FindLUSlength(string a, string b) {
        return a == b ? -1 : Math.Max(a.Length, b.Length);
    }
}
// @lc code=end

