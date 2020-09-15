/*
 * @lc app=leetcode id=1191 lang=csharp
 *
 * [1191] K-Concatenation Maximum Sum
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int KConcatenationMaxSum(int[] arr, int k) {
        long lacc = 0, racc = 0, tacc = 0, acc = 0, lm = 0, rm = 0, tm = 0;
        int n = arr.Length;
        for (int i = 0; i < n; ++i) {
            long curr = (long)arr[i];
            acc += curr;
            lacc += curr;
            lm = Math.Max(lacc, lm);
            racc += (long)arr[n - 1 - i];
            rm = Math.Max(racc, rm);
            tacc = Math.Max(0, tacc) + curr;
            tm = Math.Max(tacc, tm);
        }
        if (k == 1) {
            return (int)(tm % 1000000007);
        }
        return (int)(Math.Max(tm, lm + Math.Max(0, acc * ((long)k - 2)) + rm) % 1000000007);
    }
}
// @lc code=end

