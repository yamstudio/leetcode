/*
 * @lc app=leetcode id=482 lang=csharp
 *
 * [482] License Key Formatting
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public string LicenseKeyFormatting(string S, int K) {
        LinkedList<char> ret = new LinkedList<char>();
        int count = 0;
        for (int i = S.Length - 1; i >= 0; --i) {
            char c = S[i];
            if (c != '-') {
                ret.AddFirst(char.ToUpper(c));
                ++count;
            }
            if (count == K) {
                ret.AddFirst('-');
                count = 0;
            }
        }
        if (ret.Count > 0 && ret.First.Value == '-') {
            ret.RemoveFirst();
        }
        return new string(ret.ToArray());
    }
}
// @lc code=end

