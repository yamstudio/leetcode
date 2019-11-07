/*
 * @lc app=leetcode id=633 lang=csharp
 *
 * [633] Sum of Square Numbers
 */

using System;

// @lc code=start
public class Solution {
    public bool JudgeSquareSum(int c) {
        int h = c / 2;
        for (int i = 0; i * i <= h; ++i) {
            int r = (int) Math.Sqrt(c - i * i);
            if (r * r + i * i == c) {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end

