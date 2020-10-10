/*
 * @lc app=leetcode id=1313 lang=csharp
 *
 * [1313] Decompress Run-Length Encoded List
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int[] DecompressRLElist(int[] nums) {
        return nums
            .Select((int val, int i) => (Value: val, Index: i))
            .GroupBy(t => t.Index / 2, (int k, IEnumerable<(int Value, int Index)> pair) => Enumerable.Repeat(pair.ElementAt(1).Value, pair.First().Value))
            .SelectMany(p => p)
            .ToArray();
    }
}
// @lc code=end

