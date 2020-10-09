/*
 * @lc app=leetcode id=1312 lang=csharp
 *
 * [1312] Minimum Insertion Steps to Make a String Palindrome
 */

using System;

// @lc code=start
public class Solution {

    private static int MinInsertionsRecurse(string s, int l, int r, int[,] memo) {
        if (l >= r) {
            return 1;
        }
        if (memo[l, r] != 0) {
            return memo[l, r];
        }
        if (s[l] == s[r]) {
            return memo[l, r] = MinInsertionsRecurse(s, l + 1, r - 1, memo);
        }
        return memo[l, r] = Math.Min(MinInsertionsRecurse(s, l + 1, r, memo), MinInsertionsRecurse(s, l, r - 1, memo)) + 1;
    }

    public int MinInsertions(string s) {
        int n = s.Length;
        return MinInsertionsRecurse(s, 0, n - 1, new int[n, n]) - 1;
    }
}
// @lc code=end

