/*
 * @lc app=leetcode id=556 lang=csharp
 *
 * [556] Next Greater Element III
 */

using System;

// @lc code=start
public class Solution {
    public int NextGreaterElement(int n) {
        var s = n.ToString().ToCharArray();
        int l = s.Length, i;
        for (i = l - 1; i > 0; --i) {
            if (s[i] > s[i - 1]) {
                break;
            }
        }
        if (i == 0) {
            return -1;
        }
        char curr = s[i - 1];
        for (int j = l - 1; j >= 0; --j) {
            if (s[j] > curr) {
                s[i - 1] = s[j];
                s[j] = curr;
                break;
            }
        }
        Array.Sort(s, i, l - i);
        long ret = long.Parse(s);
        return ret > (long) int.MaxValue ? -1 : (int) ret;
    }
}
// @lc code=end

