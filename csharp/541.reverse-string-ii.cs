/*
 * @lc app=leetcode id=541 lang=csharp
 *
 * [541] Reverse String II
 */

using System.Linq;

// @lc code=start
public class Solution {
    public string ReverseStr(string s, int k) {
        return new string(Enumerable.Range(0, s.Length).Select(i => {
            int r = i % (2 * k);
            return s[r >= k ? i : (i - r + k > s.Length ? (i - 2 * r + s.Length % k - 1) : (i - 2 * r + k - 1))];
        }).ToArray());
    }
}
// @lc code=end

