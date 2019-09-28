/*
 * @lc app=leetcode id=467 lang=csharp
 *
 * [467] Unique Substrings in Wraparound String
 */

using System.Collections.Generic;

public class Solution {
    public int FindSubstringInWraproundString(string p) {
        int len = 0, ret = 0, n = p.Length;
        int[] max = new int[26];
        for (int i = 0; i < n; ++i) {
            int curr = (int) p[i], prev = i > 0 ? (int) p[i - 1] : 0;
            if (i > 0 && curr == prev + 1 || curr == prev - 25) {
                ++len;
            } else {
                len = 1;
            }
            max[curr - 'a'] = Math.Max(len, max[curr - 'a']);
        }
        foreach (int num in max) {
            ret += num;
        }
        return ret;
    }
}

