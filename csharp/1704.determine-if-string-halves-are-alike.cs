/*
 * @lc app=leetcode id=1704 lang=csharp
 *
 * [1704] Determine if String Halves Are Alike
 */

using System.Collections;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public bool HalvesAreAlike(string s) {
        ISet<char> vowels = new HashSet<char>() {
            'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'
        };
        int lcount = 0, rcount = 0;
        int l = s.Length, h = l / 2;
        for (int i = 0; i < h; ++i) {
            if (vowels.Contains(s[i])) {
                ++lcount;
            }
        }
        for (int i = h; i < l; ++i) {
            if (vowels.Contains(s[i])) {
                ++rcount;
            }
        }
        return lcount == rcount;
    }
}
// @lc code=end

