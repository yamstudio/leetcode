/*
 * @lc app=leetcode id=822 lang=csharp
 *
 * [822] Card Flipping Game
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int Flipgame(int[] fronts, int[] backs) {
        var set = new HashSet<int>(fronts.Union(backs));
        foreach (int x in fronts.Zip(backs, (a, b) => (Front: a, Back: b)).Where(tuple => tuple.Front == tuple.Back).Select(tuple => tuple.Front)) {
            set.Remove(x);
        }
        return set.DefaultIfEmpty(0).Min();
    }
}
// @lc code=end

