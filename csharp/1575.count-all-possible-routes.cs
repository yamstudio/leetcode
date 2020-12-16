/*
 * @lc app=leetcode id=1575 lang=csharp
 *
 * [1575] Count All Possible Routes
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {

    private static long CountRoutes(int[] locations, int n, int t, int i, int f, long?[,] memo) {
        if (Math.Abs(locations[t] - locations[i]) > f) {
            return 0;
        }
        if (memo[i, f].HasValue) {
            return memo[i, f].Value;
        }
        long ret = t == i ? 1 : 0;
        for (int j = 0; j < n; ++j) {
            if (i == j) {
                continue;
            }
            int d = Math.Abs(locations[j] - locations[i]);
            if (d <= f) {
                ret = (ret + CountRoutes(locations, n, t, j, f - d, memo)) % 1000000007;
            }
        }
        memo[i, f] = ret;
        return ret;
    }

    public int CountRoutes(int[] locations, int start, int finish, int fuel) {
        int n = locations.Length;
        return (int)CountRoutes(locations, n, finish, start, fuel, new long?[n, fuel + 1]);
    }
}
// @lc code=end

