/*
 * @lc app=leetcode id=955 lang=csharp
 *
 * [955] Delete Columns to Make Sorted II
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int MinDeletionSize(string[] A) {
        int n = A.Length, m = A[0].Length, ret = 0;
        bool[] stop = new bool[n];
        for (int j = 0; j < m; ++j) {
            var chars = A.Select(s => s[j]);
            if (chars
                .Zip(chars.Skip(1), (char curr, char next) => curr > next)
                .Zip(stop, (bool b1, bool b2) => b1 && !b2)
                .Any(b => b)) {
                ++ret;
            } else {
                for (int i = 0; i < n - 1; ++i) {
                    if (A[i][j] < A[i + 1][j]) {
                        stop[i] = true;
                    }
                }
            }
        }
        return ret;
    }
}
// @lc code=end

