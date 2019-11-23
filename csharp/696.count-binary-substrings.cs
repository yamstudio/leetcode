/*
 * @lc app=leetcode id=696 lang=csharp
 *
 * [696] Count Binary Substrings
 */

// @lc code=start
public class Solution {
    public int CountBinarySubstrings(string s) {
        int ret = 0, prev = 0, i = 0, n = s.Length;
        while (i < n) {
            char c = s[i];
            int j;
            for (j = i; j < n && s[j] == c; ++j);
            int count = j - i;
            ret += Math.Min(count, prev);
            prev = count;
            i = j;
        }
        return ret;
    }
}
// @lc code=end

