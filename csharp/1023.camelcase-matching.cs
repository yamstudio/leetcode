/*
 * @lc app=leetcode id=1023 lang=csharp
 *
 * [1023] Camelcase Matching
 */

using System.Linq;

// @lc code=start
public class Solution {

    private static bool IsMatch(string query, string pattern) {
        int m = query.Length, n = pattern.Length, j = 0;
        for (int i = 0; i < m; ++i) {
            char c = query[i];
            if (j < n && c == pattern[j]) {
                ++j;
            } else if (c < 'a' || c > 'z') {
                return false;
            }
        }
        return j == n;
    }

    public IList<bool> CamelMatch(string[] queries, string pattern) {
        return queries
            .Select(query => IsMatch(query, pattern))
            .ToList();
    }
}
// @lc code=end

