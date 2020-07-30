/*
 * @lc app=leetcode id=975 lang=csharp
 *
 * [975] Odd Even Jump
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    private static int GetUpper(SortedList<int, int> sorted, int val) {
        var keys = sorted.Keys;
        int l = 0, r = keys.Count;
        while (l < r) {
            int m = (l + r) / 2;
            if (keys[m] < val) {
                l = m + 1;
            } else {
                r = m;
            }
        }
        return r;
    }

    public int OddEvenJumps(int[] A) {
        int n = A.Length, ret = 1;
        var dp = new bool[n, 2];
        var sorted = new SortedList<int, int>();
        dp[n - 1, 0] = true;
        dp[n - 1, 1] = true;
        sorted[A[n - 1]] = n - 1;
        for (int i = n - 2; i >= 0; i--) {
            int val = A[i], u = GetUpper(sorted, val);
            if (u < sorted.Count) {
                if (dp[sorted.Values[u], 1]) {
                    dp[i, 0] = true;
                    ++ret;
                }
            }
            int l = u == sorted.Count || sorted.Keys[u] != val ? u - 1 : u;
            if (l >= 0) {
                dp[i, 1] = dp[sorted.Values[l], 0];
            }
            sorted[val] = i;
        }
        return ret;
    }
}
// @lc code=end

