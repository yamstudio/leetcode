/*
 * @lc app=leetcode id=274 lang=csharp
 *
 * [274] H-Index
 */

using System;

public class Solution {
    public int HIndex(int[] citations) {
        int n = citations.Length;
        Array.Sort(citations, new Comparison<int>((a, b) => b.CompareTo(a)));
        for (int h = 0; h < n; ++h) {
            if (h >= citations[h]) {
                return h;
            }
        }
        return n;
    }
}

