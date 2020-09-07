/*
 * @lc app=leetcode id=1147 lang=csharp
 *
 * [1147] Longest Chunked Palindrome Decomposition
 */

using System.Text;

// @lc code=start
public class Solution {
    public int LongestDecomposition(string text) {
        int n = text.Length;
        StringBuilder l = new StringBuilder(), r = new StringBuilder();
        for (int i = 0; i < n / 2; ++i) {
            l.Append(text[i]);
            r.Insert(0, text[n - 1 - i]);
            if (l.ToString() == r.ToString()) {
                return 2 + LongestDecomposition(text.Substring(i + 1, n - i * 2 - 2));
            }
        }
        return n > 0 ? 1 : 0;
    }
}
// @lc code=end

