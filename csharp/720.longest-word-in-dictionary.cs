/*
 * @lc app=leetcode id=720 lang=csharp
 *
 * [720] Longest Word in Dictionary
 */

using System.Collections.Generic;
using System.Text;

// @lc code=start
public class Solution {
    public string LongestWord(string[] words) {
        string ret = "";
        ISet<string> set = new HashSet<string>(words);
        foreach (string word in set) {
            int len = word.Length;
            if (len < ret.Length || (len == ret.Length && word.CompareTo(ret) > 0)) {
                continue;
            }
            bool okay = true;
            StringBuilder sb = new StringBuilder();
            foreach (var c in word) {
                sb.Append(c);
                if (!set.Contains(sb.ToString())) {
                    okay = false;
                    break;
                }
            }
            if (okay) {
                ret = word;
            }
        }
        return ret;
    }
}
// @lc code=end

