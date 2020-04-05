/*
 * @lc app=leetcode id=849 lang=csharp
 *
 * [849] Maximize Distance to Closest Person
 */

using System;

// @lc code=start
public class Solution {
    public int MaxDistToClosest(int[] seats) {
        int i, p = -1, n = seats.Length, ret = -1;
        for (i = 0; i < n; ++i) {
            if (seats[i] == 1) {
                if (p < 0) {
                    ret = i;
                } else {
                    ret = Math.Max(ret, (i - p) / 2);
                }
                p = i;
            }
        }
        ret = Math.Max(ret, n - p - 1);
        return ret;
    }
}
// @lc code=end

