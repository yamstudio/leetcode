/*
 * @lc app=leetcode id=1447 lang=csharp
 *
 * [1447] Simplified Fractions
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int Gcd(int a, int b) {
        return b == 0 ? a : Gcd(b, a % b);
    }

    public IList<string> SimplifiedFractions(int n) {
        return Enumerable
            .Range(2, n - 1)
            .SelectMany(d => Enumerable
                .Range(1, d - 1)
                .Where(k => Gcd(k, d) == 1)
                .Select(k => $"{k}/{d}"))
            .ToList();
    }
}
// @lc code=end

