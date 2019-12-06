/*
 * @lc app=leetcode id=722 lang=csharp
 *
 * [722] Remove Comments
 */

using System.Collections.Generic;
using System.Text;

// @lc code=start
public class Solution {
    public IList<string> RemoveComments(string[] source) {
        IList<string> ret = new List<string>();
        StringBuilder sb = new StringBuilder();
        bool isBlock = false;
        foreach (var line in source) {
            int len = line.Length;
            for (int i = 0; i < len; ++i) {
                char c = line[i];
                if (isBlock) {
                    if (i < len - 1 && c == '*' && line[i + 1] == '/') {
                        isBlock = false;
                        ++i;
                    }
                    continue;
                }
                if (i == len - 1) {
                    sb.Append(c);
                    continue;
                }
                if (c == '/') {
                    if (line[i + 1] == '/') {
                        break;
                    }
                    if (line[i + 1] == '*') {
                        isBlock = true;
                        ++i;
                        continue;
                    }
                }
                sb.Append(c);
            }
            if (!isBlock && sb.Length > 0) {
                ret.Add(sb.ToString());
                sb.Clear();
            }
        }
        return ret;
    }
}
// @lc code=end

