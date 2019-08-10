/*
 * @lc app=leetcode id=214 lang=csharp
 *
 * [214] Shortest Palindrome
 */

using System;

public class Solution {
    public string ShortestPalindrome(string s) {
        var arr = s.ToCharArray();
        Array.Reverse(arr);
        string rev = new string(arr);
        string t = s + '$' + rev;
        int[] next = new int[t.Length];
        for (int i = 1; i < t.Length; ++i) {
            int j = next[i - 1];
            while (j > 0 && t[i] != t[j]) {
                j = next[j - 1];
            }
            if (t[i] == t[j]) {
                j += 1;
            }
            next[i] = j;
        }
        return rev.Substring(0, rev.Length - next[t.Length - 1]) + s;
    }
}

