/*
 * @lc app=leetcode id=507 lang=csharp
 *
 * [507] Perfect Number
 */

using System;

// @lc code=start
public class Solution {
    public bool CheckPerfectNumber(int num) {
        if (num <= 1) {
            return false;
        }
        int n = num, s = (int) Math.Sqrt((double) num);
        for (int i = 1; i <= s && n >= 0; ++i) {
            if (num % i != 0) {
                continue;
            }
            int j = num / i;
            n -= i;
            if (j != num && j != i) {
                n -= j;
            }
        }
        return n == 0;
    }
}
// @lc code=end

