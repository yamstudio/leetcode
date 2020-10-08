/*
 * @lc app=leetcode id=1309 lang=csharp
 *
 * [1309] Decrypt String from Alphabet to Integer Mapping
 */

using System.Text;

// @lc code=start
public class Solution {
    public string FreqAlphabets(string s) {
        int n = s.Length;
        var sb = new StringBuilder();
        for (int i = 0; i < n; ++i) {
            if (i + 2 < n && s[i + 2] == '#') {
                sb.Append((char)(10 * ((int)s[i] - (int)'0') + (int)s[i + 1] - (int)'0' + (int)'a' - 1));
                i += 2;
            } else {
                sb.Append((char)((int)s[i] - (int)'0' - 1 + (int)'a'));
            }
        }
        return sb.ToString();
    }
}
// @lc code=end

