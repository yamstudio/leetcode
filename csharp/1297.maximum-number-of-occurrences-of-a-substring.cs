/*
 * @lc app=leetcode id=1297 lang=csharp
 *
 * [1297] Maximum Number of Occurrences of a Substring
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int MaxFreq(string s, int maxLetters, int minSize, int maxSize) {
        var count = new Dictionary<string, int>();
        int l = 0, charCount = 0, n = s.Length;
        int[] chars = new int[26];
        for (int r = 0; r < n; ++r) {
            int c = (int)s[r] - (int)'a';
            if (chars[c]++ == 0) {
                ++charCount;
            }
            if (r - l >= minSize) {
                int p = (int)s[l++] - (int)'a';
                if (--chars[p] == 0) {
                    --charCount;
                }
            }
            if (r - l + 1 == minSize && charCount <= maxLetters) {
                string sub = s.Substring(l, minSize);
                if (count.TryGetValue(sub, out int t)) {
                    count[sub] = t + 1;
                } else {
                    count[sub] = 1;
                }
            }
        }
        return count.Values.DefaultIfEmpty().Max();
    }
}
// @lc code=end

