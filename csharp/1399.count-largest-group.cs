/*
 * @lc app=leetcode id=1399 lang=csharp
 *
 * [1399] Count Largest Group
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int CountLargestGroup(int n) {
        var grouped = Enumerable
            .Range(1, n)
            .GroupBy(x => {
                int ret = 0;
                while (x > 0) {
                    ret += x % 10;
                    x /= 10;
                }
                return ret;
            }, (x, a) => a.Count())
            .GroupBy(t => t, (t, a) => (Value: t, Count: a.Count()))
            .ToDictionary(t => t.Value, t => t.Count);
        return grouped[grouped.Keys.Max()];
    }
}
// @lc code=end

