/*
 * @lc app=leetcode id=1561 lang=csharp
 *
 * [1561] Maximum Number of Coins You Can Get
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int MaxCoins(int[] piles) {
        int n = piles.Length;
        return piles
            .OrderBy(x => x)
            .Skip(n / 3)
            .Where((x, i) => i % 2 == 0)
            .Sum();
    }
}
// @lc code=end

