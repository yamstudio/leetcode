/*
 * @lc app=leetcode id=1138 lang=csharp
 *
 * [1138] Alphabet Board Path
 */

using System.Text;

// @lc code=start
public class Solution {
    public string AlphabetBoardPath(string target) {
        int r = 0, c = 0;
        var sb = new StringBuilder();
        foreach (char t in target) {
            int ti = (int)t - (int)'a', tr = ti / 5, tc = ti % 5;
            while (r != tr || c != tc) {
                if (r != 5 && c > tc) {
                    sb.Append('L');
                    --c;
                } else if (r != 5 && c < tc) {
                    sb.Append('R');
                    ++c;
                } else if (r < tr) {
                    sb.Append('D');
                    ++r;
                } else {
                    sb.Append('U');
                    --r;
                }
            }
            sb.Append('!');
        }
        return sb.ToString();
    }
}
// @lc code=end

