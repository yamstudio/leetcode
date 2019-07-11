/*
 * @lc app=leetcode id=68 lang=csharp
 *
 * [68] Text Justification
 */

using System.Collections.Generic;
using System.Text;

public class Solution {
    public IList<string> FullJustify(string[] words, int maxWidth) {
        IList<string> ret = new List<string>();
        if (words.Length == 0) {
            return ret;
        }
        StringBuilder sb = new StringBuilder(maxWidth);
        int left = 0, len = words[0].Length;
        for (int i = 1; i < words.Length; ++i) {
            if (words[i].Length + len + i - left > maxWidth) {
                int spaces = maxWidth - len, count = i - left - 1;
                for (int j = left; j < i; ++j) {
                    int slen;
                    if (count == 0) {
                        slen = spaces;
                    } else if (j < i - 1) {
                        slen = spaces / count + (j - left < spaces % count ? 1 : 0);
                    } else {
                        slen = 0;
                    }
                    sb.Append(words[j]);
                    while (slen-- > 0) {
                        sb.Append(' ');
                    }
                }
                ret.Add(sb.ToString());
                sb.Clear();
                left = i;
                len = words[i].Length;
            } else {
                len += words[i].Length;
            }
        }

        int s = maxWidth - len;
        for (int i = left; i < words.Length; ++i) {
            sb.Append(words[i]);
            if (s-- > 0) {
                sb.Append(' ');
            }
        }
        while (s-- > 0) {
            sb.Append(' ');
        }
        ret.Add(sb.ToString());

        return ret;
    }
}

