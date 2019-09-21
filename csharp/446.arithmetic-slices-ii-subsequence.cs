/*
 * @lc app=leetcode id=446 lang=csharp
 *
 * [446] Arithmetic Slices II - Subsequence
 */

using System.Collections.Generic;

public class Solution {
    public int NumberOfArithmeticSlices(int[] A) {
        int n = A.Length, ret = 0;
        IDictionary<long, int>[] dp = new Dictionary<long, int>[n];
        for (int i = 0; i < n; ++i) {
            var dict = new Dictionary<long, int>();
            for (int j = 0; j < i; ++j) {
                long diff = (long) A[i] - (long) A[j];
                dict[diff] = 1 + (dict.ContainsKey(diff) ? dict[diff] : 0);
                if (dp[j].ContainsKey(diff)) {
                    int count = dp[j][diff];
                    ret += count;
                    dict[diff] += count;
                }
            }
            dp[i] = dict;
        }
        return ret;
    }
}

