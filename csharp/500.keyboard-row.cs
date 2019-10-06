/*
 * @lc app=leetcode id=500 lang=csharp
 *
 * [500] Keyboard Row
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static ISet<char>[] Rows = new ISet<char>[]
    {
        new HashSet<char>()
        {
            'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p',
        },
        new HashSet<char>()
        {
            'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l',
        },
        new HashSet<char>()
        {
            'z', 'x', 'c', 'v', 'b', 'n', 'm',
        },
    };

    public string[] FindWords(string[] words) {
        IList<string> ret = new List<string>();
        foreach (string word in words) {
            int n = word.Length;
            if (n == 0) {
                ret.Add(word);
                break;
            }
            ISet<char> set = null;
            foreach (var row in Rows) {
                if (row.Contains(char.ToLower(word[0]))) {
                    set = row;
                    break;
                }
            }
            bool okay = true;
            for (int i = 1; i < n; ++i) {
                if (!set.Contains(char.ToLower(word[i]))) {
                    okay = false;
                    break;
                }
            }
            if (okay) {
                ret.Add(word);
            }
        }
        return ret.ToArray();
    }
}
// @lc code=end

