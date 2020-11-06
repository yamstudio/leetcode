/*
 * @lc app=leetcode id=1410 lang=csharp
 *
 * [1410] HTML Entity Parser
 */

using System.Collections.Generic;
using System.Text;

// @lc code=start
public class Solution {

    private static IDictionary<string, char> Specials = new Dictionary<string, char>()
    {
        { "&quot;", '\"' },
        { "&apos;", '\'' },
        { "&amp;", '&' },
        { "&gt;", '>' },
        { "&lt;", '<' },
        { "&frasl;", '/' },
    };

    public string EntityParser(string text) {
        int n = text.Length;
        var ret = new StringBuilder();
        for (int i = 0; i < n; ++i) {
            if (text[i] != '&') {
                ret.Append(text[i]);
                continue;
            }
            bool flag = false;
            foreach (var t in Specials) {
                if (i + t.Key.Length > n) {
                    continue;
                }
                if (t.Key == text.Substring(i, t.Key.Length)) {
                    flag = true;
                    i += t.Key.Length - 1;
                    ret.Append(t.Value);
                    break;
                }
            }
            if (!flag) {
                ret.Append(text[i]);
            }
        }
        return ret.ToString();
    }
}
// @lc code=end

