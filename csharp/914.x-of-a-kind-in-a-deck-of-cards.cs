/*
 * @lc app=leetcode id=914 lang=csharp
 *
 * [914] X of a Kind in a Deck of Cards
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int GetGreatestCommonDivisor(int a, int b) {
        return a == 0 ? b : GetGreatestCommonDivisor(b % a, a);
    }

    public bool HasGroupsSizeX(int[] deck) {
        int gcd = 0;
        foreach (int x in deck.GroupBy(x => x, (int x, IEnumerable<int> list) => list.Count())) {
            gcd = GetGreatestCommonDivisor(gcd, x);
            if (gcd < 2) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

