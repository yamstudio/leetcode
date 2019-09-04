/*
 * @lc app=leetcode id=345 lang=csharp
 *
 * [345] Reverse Vowels of a String
 */

using System.Collections.Generic;

public class Solution {

    private static ISet<char> Vowels = new HashSet<char>
    {
        'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U',
    };

    public string ReverseVowels(string s) {
        int l = 0, n = s.Length, r = n - 1;
        char[] ret = new char[n];
        while (l <= r) {
            char cl = s[l];
            if (!Vowels.Contains(cl)) {
                ret[l++] = cl;
                continue;
            }
            char cr = s[r];
            if (!Vowels.Contains(cr)) {
                ret[r--] = cr;
                continue;
            }
            ret[l++] = cr;
            ret[r--] = cl;
        }
        return new string(ret);
    }
}

