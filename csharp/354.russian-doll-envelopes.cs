/*
 * @lc app=leetcode id=354 lang=csharp
 *
 * [354] Russian Doll Envelopes
 */

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int MaxEnvelopes(int[][] envelopes) {
        IList<int> dp = new List<int>();
        Array.Sort(envelopes, Comparer<int[]>.Create((int[] a, int[] b) => a[0] == b[0] ? b[1].CompareTo(a[1]) : a[0].CompareTo(b[0])));
        foreach (int h in envelopes.Select(a => a[1])) {
            int left = 0, right = dp.Count;
            while (left < right) {
                int mid = left + (right - left) / 2;
                if (dp[mid] < h) {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
            if (right == dp.Count) {
                dp.Add(h);
            } else {
                dp[right] = h;
            }
        }
        return dp.Count;
    }
}

