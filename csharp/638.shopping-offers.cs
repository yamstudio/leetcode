/*
 * @lc app=leetcode id=638 lang=csharp
 *
 * [638] Shopping Offers
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs) {
        int total = price.Count;
        return special
            .Select(s => (s.Take(total).Zip(needs, (o, n) => n - o).ToList(), s[total]))
            .Where(pair => pair.Item1.All(x => x >= 0))
            .Select(pair => pair.Item2 + ShoppingOffers(price, special, pair.Item1))
            .Aggregate(Enumerable.Zip(price, needs, (p, n) => p * n).Sum(), Math.Min);
    }
}
// @lc code=end

