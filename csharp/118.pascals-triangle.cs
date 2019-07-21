/*
 * @lc app=leetcode id=118 lang=csharp
 *
 * [118] Pascal's Triangle
 */

using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var ret = new List<IList<int>>(numRows);
        for (int i = 0; i < numRows; ++i) {
            var row = new List<int>(i + 1);
            row.Add(1);
            if (i > 0) {
                var prev = ret[i - 1];
                for (int j = 1; j < i; ++j) {
                    row.Add(prev[j - 1] + prev[j]);
                }
                row.Add(1);
            }
            ret.Add(row);
        }
        return ret;
    }
}

