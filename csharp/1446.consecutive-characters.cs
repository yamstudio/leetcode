/*
 * @lc app=leetcode id=1446 lang=csharp
 *
 * [1446] Consecutive Characters
 */

using System;

// @lc code=start
public class Solution {
    public int MaxPower(string s) {
        int ret = 0, n = s.Length;
        for (int i = 0; i < n;) {
            char c = s[i];
            int ni = i + 1;
            while (ni < n && s[ni] == c) {
                ++ni;
            }
            ret = Math.Max(ret, ni - i);
            i = ni;
        }
        return ret;
    }
}
// @lc code=end

