/*
 * @lc app=leetcode id=1362 lang=csharp
 *
 * [1362] Closest Divisors
 */

using System;

// @lc code=start
public class Solution {
    public int[] ClosestDivisors(int num) {
        int n1 = num + 1, n2 = num + 2;
        for (int i = (int)Math.Sqrt(n2); i >= 1; --i) {
            if (n1 % i == 0) {
                return new int[] { i, n1 / i };
            }
            if (n2 % i == 0) {
                return new int[] { i, n2 / i };
            }
        }
        return new int[0];
    }
}
// @lc code=end

