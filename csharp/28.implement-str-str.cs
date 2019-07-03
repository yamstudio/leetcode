/*
 * @lc app=leetcode id=28 lang=csharp
 *
 * [28] Implement strStr()
 */

using System.Collections.Generic;

public class Solution {
    public int StrStr(string haystack, string needle) {
        List<int> lps = new List<int>(needle.Length + 1);
        lps.Add(-1);
        for (int j = 0; j < needle.Length; ++j) {
            int k = lps[j];
            while (k != -1 && needle[j] != needle[k]) {
                k = lps[k];
            }
            lps.Add(k + 1);
        }
        int i = 0, h = 0;
        while (true) {
            if (h == needle.Length) {
                return i - needle.Length;
            } else if (i == haystack.Length) {
                return -1;
            } else if (h == -1 || needle[h] == haystack[i]) {
                ++i;
                ++h;
            } else {
                h = lps[h];
            }
        }
        return -1;
    }
}

