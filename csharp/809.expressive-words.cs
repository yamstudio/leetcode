/*
 * @lc app=leetcode id=809 lang=csharp
 *
 * [809] Expressive Words
 */

using System.Linq;
using System.Text;

// @lc code=start
using System.Text.RegularExpressions;
public class Solution {
    public int ExpressiveWords(string S, string[] words) {
        var sb = new StringBuilder();
        char curr = '^';
        int count = 1;
        foreach (var c in S.Append('$')) {
            if (c == curr) {
                ++count;
                continue;
            }
            if (count == 1) {
                sb.Append(curr);
            } else if (count == 2) {
                sb.Append(curr);
                sb.Append(curr);
            } else {
                sb.Append($"[{curr}]{{1,{count}}}");
            }
            curr = c;
            count = 1;
        }
        sb.Append('$');
        var pattern = new Regex(sb.ToString(), RegexOptions.Compiled);
        return words.Where(s => pattern.IsMatch(s)).Count();
    }
}
// @lc code=end

