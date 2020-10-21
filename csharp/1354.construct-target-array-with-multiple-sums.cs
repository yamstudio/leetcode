/*
 * @lc app=leetcode id=1354 lang=csharp
 *
 * [1354] Construct Target Array With Multiple Sums
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public bool IsPossible(int[] target) {
        long sum = target.Sum(x => (long)x);
        var sorted = new SortedSet<(long Value, int Index)>(target.Select((x, i) => (Value: (long)x, Index: i)));
        while (sorted.Max.Value > 1) {
            var curr = sorted.Max;
            long others = sum - curr.Value;
            if (others == 0) {
                return false;
            }
            if (others == 1) {
                break;
            }
            long val = curr.Value % others;
            if (others > curr.Value || val == 0) {
                return false;
            }
            sum = others + val;
            sorted.Remove(curr);
            sorted.Add((Value: val, Index: curr.Index));
        }
        return true;
    }
}
// @lc code=end

