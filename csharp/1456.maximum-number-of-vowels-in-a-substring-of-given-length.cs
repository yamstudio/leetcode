/*
 * @lc app=leetcode id=1456 lang=csharp
 *
 * [1456] Maximum Number of Vowels in a Substring of Given Length
 */

using System;

// @lc code=start
public class Solution {

    private const int Vowels = (1 << 0) | (1 << 4) | (1 << 8) | (1 << 14) | (1 << 20);

    public int MaxVowels(string s, int k) {
        int n = s.Length, l = 0, ret = 0, acc = 0;
        for (int r = 0; r < n && ret < k; ++r) {
            if ((Vowels & (1 << ((int)s[r] - (int)'a'))) != 0) {
                ++acc;
            }
            if (l + k == r) {
                if ((Vowels & (1 << ((int)s[l++] - (int)'a'))) != 0) {
                    --acc;
                }
            }
            ret = Math.Max(acc, ret);
        }
        return ret;
    }
}
// @lc code=end

