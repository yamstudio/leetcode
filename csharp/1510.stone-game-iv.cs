/*
 * @lc app=leetcode id=1510 lang=csharp
 *
 * [1510] Stone Game IV
 */

using System;

// @lc code=start
public class Solution {

    private static bool WinnerSquareGame(int n, bool?[] memo) {
        int d = (int)Math.Sqrt(n);
        if (d * d == n) {
            return true;
        }
        if (memo[n].HasValue) {
            return memo[n].Value;
        }
        for (int i = 1; i <= d; ++i) {
            if (!WinnerSquareGame(n - i * i, memo)) {
                memo[n] = true;
                return true;
            }
        }
        memo[n] = false;
        return false;
    }

    public bool WinnerSquareGame(int n) {
        return WinnerSquareGame(n, new bool?[n + 1]);
    }
}
// @lc code=end

