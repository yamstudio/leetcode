/*
 * @lc app=leetcode id=1553 lang=csharp
 *
 * [1553] Minimum Number of Days to Eat N Oranges
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int MinDays(int n, IDictionary<int, int> memo) {
        if (n <= 2) {
            return n;
        }
        if (memo.TryGetValue(n, out var c)) {
            return c;
        }
        int ret = Math.Min(n % 2 + MinDays(n / 2, memo), n % 3 + MinDays(n / 3, memo)) + 1;
        memo[n] = ret;
        return ret;
    }

    public int MinDays(int n) {
        return MinDays(n, new Dictionary<int, int>());
    }
}
// @lc code=end

