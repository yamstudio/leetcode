/*
 * @lc app=leetcode id=1189 lang=csharp
 *
 * [1189] Maximum Number of Balloons
 */

using System;

// @lc code=start
public class Solution {
    public int MaxNumberOfBalloons(string text) {
        int b = 0, a = 0, l = 0, o = 0, n = 0;
        foreach (var c in text) {
            switch (c) {
                case 'b':
                    ++b;
                    break;
                case 'a':
                    ++a;
                    break;
                case 'l':
                    ++l;
                    break;
                case 'o':
                    ++o;
                    break;
                case 'n':
                    ++n;
                    break;
                default:
                    break;
            }
        }
        return Math.Min(b, Math.Min(a, Math.Min(l / 2, Math.Min(o / 2, n))));
    }
}
// @lc code=end

