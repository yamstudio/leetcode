/*
 * @lc app=leetcode id=944 lang=csharp
 *
 * [944] Delete Columns to Make Sorted
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int MinDeletionSize(string[] A) {
        int n = A.Length, l = A[0].Length;
        return Enumerable
            .Range(0, l)
            .Count((int i) => !Enumerable
                .Range(0, n - 1)
                .All((int j) => A[j][i] <= A[j + 1][i]));
    }
}
// @lc code=end

