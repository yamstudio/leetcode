/*
 * @lc app=leetcode id=806 lang=csharp
 *
 * [806] Number of Lines To Write String
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int[] NumberOfLines(int[] widths, string S) {
        return S
            .Select(c => widths[(int)c - (int)'a'])
            .Aggregate(
                (Line: 1, Count: 0), 
                (tuple, length) => 
                    length + tuple.Count > 100 ? 
                    (Line: tuple.Line + 1, Count: length) : 
                    (Line: tuple.Line, Count: tuple.Count + length), 
                tuple => new int[]{ tuple.Line, tuple.Count });
    }
}
// @lc code=end

