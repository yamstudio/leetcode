/*
 * @lc app=leetcode id=1072 lang=csharp
 *
 * [1072] Flip Columns For Maximum Number of Equal Rows
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int MaxEqualRowsAfterFlips(int[][] matrix) {
        return matrix
            .Select(row => new string(row
                .Select(x => (char)((x ^ row[0]) + (int)'0'))
                .ToArray()))
            .GroupBy(row => row, (string k, IEnumerable<string> all) => all.Count())
            .Max();
    }
}
// @lc code=end

