/*
 * @lc app=leetcode id=899 lang=csharp
 *
 * [899] Orderly Queue
 */

using System.Linq;

// @lc code=start
public class Solution {
    public string OrderlyQueue(string S, int K) {
        if (K > 1) {
            return new string(S.OrderBy(c => c).ToArray());
        }
        return Enumerable
            .Range(0, S.Length)
            .Aggregate(
                (Min: S, Curr: S),
                (tuple, i) => (
                    Min: tuple.Min.CompareTo(tuple.Curr) <= 0 ? tuple.Min : tuple.Curr,
                    Curr: new string(tuple.Curr.Skip(1).Append(tuple.Curr[0]).ToArray())
                ),
                tuple => tuple.Min
            );
    }
}
// @lc code=end

