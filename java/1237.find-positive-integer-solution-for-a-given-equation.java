/*
 * @lc app=leetcode id=1237 lang=java
 *
 * [1237] Find Positive Integer Solution for a Given Equation
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
/*
 * // This is the custom function interface.
 * // You should not implement it, or speculate about its implementation
 * class CustomFunction {
 *     // Returns f(x, y) for any given positive integers x and y.
 *     // Note that f(x, y) is increasing with respect to both x and y.
 *     // i.e. f(x, y) < f(x + 1, y), f(x, y) < f(x, y + 1)
 *     public int f(int x, int y);
 * };
 */

class Solution {
    public List<List<Integer>> findSolution(CustomFunction customfunction, int z) {
        List<List<Integer>> ret = new ArrayList<>();
        int x = 1, y = 1000;
        while (x <= 1000 && y >= 1) {
            int f = customfunction.f(x, y);
            if (f == z) {
                ret.add(List.of(x, y));
                ++x;
                --y;
            } else if (f > z) {
                --y;
            } else {
                ++x;
            }
        }
        return ret;
    }
}
// @lc code=end

interface CustomFunction {
    int f(int x, int y);
};
