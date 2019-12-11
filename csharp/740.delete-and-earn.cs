/*
 * @lc app=leetcode id=740 lang=csharp
 *
 * [740] Delete and Earn
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int DeleteAndEarn(int[] nums) {
        var map = new Dictionary<int, int>();
        foreach (int num in nums) {
            map.TryGetValue(num, out int val);
            map[num] = num + val;
        }
        return (map as IEnumerable<KeyValuePair<int, int>>)
            .OrderBy(pair => pair.Key)
            .Aggregate(
                (Prev: -2, Take: 0, Skip: 0),
                (acc, curr) => {
                    int m = Math.Max(acc.Take, acc.Skip);
                    if (acc.Prev == curr.Key - 1) {
                        return (Prev: curr.Key, Take: curr.Value + acc.Skip, Skip: m);
                    }
                    return (Prev: curr.Key, Take: curr.Value + m, Skip: m);
                },
                acc => Math.Max(acc.Take, acc.Skip)
            );

    }
}
// @lc code=end

