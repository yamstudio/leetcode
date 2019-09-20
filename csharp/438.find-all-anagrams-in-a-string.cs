/*
 * @lc app=leetcode id=438 lang=csharp
 *
 * [438] Find All Anagrams in a String
 */

using System.Collections.Generic;
using System.Linq;

public class Solution {
    public IList<int> FindAnagrams(string s, string p) {
        int n = s.Length, m = p.Length, match = 0;
        IList<int> ret = new List<int>();
        if (m > n) {
            return ret;
        }
        int[] pmap = new int[26], smap = new int[26];
        foreach (int x in p.Select(c => (int) c - (int) 'a')) {
            pmap[x]++;
        }
        for (int i = 0; i < n; ++i) {
            int x = (int) s[i] - (int) 'a';
            if (i >= m) {
                int z = (int) s[i - m] - (int) 'a';
                if ((smap[z]--) <= pmap[z]) {
                    --match;
                }
            }
            if ((++smap[x]) <= pmap[x]) {
                ++match;
            }
            if (match == m) {
                ret.Add(i - m + 1);
            }
        }
        return ret;
    }
}

