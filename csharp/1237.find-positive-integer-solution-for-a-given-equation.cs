/*
 * @lc app=leetcode id=1237 lang=csharp
 *
 * [1237] Find Positive Integer Solution for a Given Equation
 */

using System.Collections.Generic;

// @lc code=start
/*
 * // This is the custom function interface.
 * // You should not implement it, or speculate about its implementation
 * public class CustomFunction {
 *     // Returns f(x, y) for any given positive integers x and y.
 *     // Note that f(x, y) is increasing with respect to both x and y.
 *     // i.e. f(x, y) < f(x + 1, y), f(x, y) < f(x, y + 1)
 *     public int f(int x, int y);
 * };
 */

public class Solution {
    public IList<IList<int>> FindSolution(CustomFunction customfunction, int z) {
        var ret = new List<IList<int>>();
        int x = 1, y = 1000;
        while (x <= 1000 && y > 0) {
            var v = customfunction.f(x, y);
            if (v == z) {
                ret.Add(new List<int>() { x++, y-- });
            } else if (v < z) {
                ++x;
            } else {
                --y;
            }
        }
        return ret;
    }
}
// @lc code=end

