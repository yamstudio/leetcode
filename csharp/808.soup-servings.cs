/*
 * @lc app=leetcode id=808 lang=csharp
 *
 * [808] Soup Servings
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static double SoupServingsRecurse(int x, int y, IDictionary<(int X, int Y), double> memo) {
        if (x <= 0) {
            return y <= 0 ? 0.5 : 1.0;
        }
        if (y <= 0) {
            return 0.0;
        }
        var key = (X: x, Y: y);
        double val;
        if (memo.TryGetValue(key, out val)) {
            return val;
        }
        val = (SoupServingsRecurse(x - 100, y, memo) + SoupServingsRecurse(x - 75, y - 25, memo) + SoupServingsRecurse(x - 50, y - 50, memo) + SoupServingsRecurse(x - 25, y - 75, memo)) / 4.0;
        memo[key] = val;
        return val;
    }

    public double SoupServings(int N) {
        return N >= 4500 ? 1.0 : SoupServingsRecurse(N, N, new Dictionary<(int X, int Y), double>());
    }
}
// @lc code=end

