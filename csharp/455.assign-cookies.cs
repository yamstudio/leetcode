/*
 * @lc app=leetcode id=455 lang=csharp
 *
 * [455] Assign Cookies
 */

using System;

public class Solution {
    public int FindContentChildren(int[] g, int[] s) {
        int m = g.Length, i = 0, ret = 0;
        Array.Sort(g);
        Array.Sort(s);
        foreach (int cookie in s) {
            if (i >= m) {
                break;
            }
            if (cookie >= g[i]) {
                ++i;
                ++ret;
            }
        }
        return ret;
    }
}

