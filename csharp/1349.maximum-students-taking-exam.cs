/*
 * @lc app=leetcode id=1349 lang=csharp
 *
 * [1349] Maximum Students Taking Exam
 */

using System;

// @lc code=start
public class Solution {
    public int MaxStudents(char[][] seats) {
        int m = seats.Length, n = seats[0].Length, t = 1 << n;
        int[,] count = new int[m + 1, t];
        int[] ones = new int[t], rows = new int[m];
        for (int i = 1; i < t; ++i) {
            ones[i] = ones[i >> 1] + (i % 2 == 1 ? 1 : 0);
        }
        for (int i = 0; i < m; ++i) {
            char[] row = seats[i];
            int acc = 0;
            for (int j = 0; j < n; ++j) {
                acc = (acc << 1) | (row[j] == '.' ? 1 : 0);
            }
            rows[i] = acc;
        }
        count[0, 0] = 1;
        for (int i = 1; i <= m; ++i) {
            int row = rows[i - 1];
            for (int s = 0; s < t; ++s) {
                if ((row & s) == s && (s & (s >> 1)) == 0) {
                    for (int p = 0; p < t; ++p) {
                        if (count[i - 1, p] != 0 && (s & (p << 1)) == 0 && (s & (p >> 1)) == 0) {
                            count[i, s] = Math.Max(count[i, s], count[i - 1, p] + ones[s]);
                        }
                    }
                }
            }
        }
        int ret = 0;
        for (int i = 0; i < t; ++i) {
            ret = Math.Max(ret, count[m, i]);
        }
        return ret - 1;
    }
}
// @lc code=end

