/*
 * @lc app=leetcode id=517 lang=csharp
 *
 * [517] Super Washing Machines
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int FindMinMoves(int[] machines) {
        int count = machines.Sum(), n = machines.Length;
        if (count % n != 0) {
            return -1;
        }
        count /= n;
        return machines.Aggregate((0, 0), (tuple, machine) => {
            int diff = machine - count;
            int total = tuple.Item1 + diff;
            int ret = Math.Max(tuple.Item2, Math.Max(Math.Abs(total), diff));
            return (total, ret);
        }, tuple => tuple.Item2);
    }
}
// @lc code=end

