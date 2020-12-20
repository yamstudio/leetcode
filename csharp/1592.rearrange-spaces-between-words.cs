/*
 * @lc app=leetcode id=1592 lang=csharp
 *
 * [1592] Rearrange Spaces Between Words
 */

using System.Collections.Generic;
using System.Text;

// @lc code=start
public class Solution {
    public string ReorderSpaces(string text) {
        var words = new List<string>();
        int n = text.Length, spaces = 0;
        for (int i = 0; i < n;) {
            if (text[i] == ' ') {
                ++spaces;
                ++i;
                continue;
            }
            int ni = i + 1;
            while (ni < n && text[ni] != ' ') {
                ++ni;
            }
            words.Add(text.Substring(i, ni - i));
            i = ni;
        }
        var sb = new StringBuilder();
        int k = words.Count;
        if (k == 1) {
            sb.Append(words[0]);
            sb.Append(' ', spaces);
        } else {
            for (int i = 0; i < k - 1; ++i) {
                sb.Append(words[i]);
                sb.Append(' ', spaces / (k - 1));
            }
            sb.Append(words[k - 1]);
            sb.Append(' ', spaces % (k - 1));
        }
        return sb.ToString();
    }
}
// @lc code=end

