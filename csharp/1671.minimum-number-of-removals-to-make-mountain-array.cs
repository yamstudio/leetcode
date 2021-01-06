/*
 * @lc app=leetcode id=1671 lang=csharp
 *
 * [1671] Minimum Number of Removals to Make Mountain Array
 */

using System;

// @lc code=start
public class Solution {
    public int MinimumMountainRemovals(int[] nums) {
        int n = nums.Length, s = 0;
        int[,] dp = new int[n, 2];
        int[] lis = new int[n], lis2 = new int[n];
        for (int i = 0; i < n; ++i) {
            int l = 0, r = s;
            while (l < r) {
                int m = (l + r) / 2;
                if (lis[m] < nums[i]) {
                    l = m + 1;
                } else {
                    r = m;
                }
            }
            lis[l] = nums[i];
            dp[i, 0] = l;
            if (l == s) {
                ++s;
            }
        }
        s = 0;
        for (int i = n - 1; i >= 0; --i) {
            int l = 0, r = s;
            while (l < r) {
                int m = (l + r) / 2;
                if (lis2[m] < nums[i]) {
                    l = m + 1;
                } else {
                    r = m;
                }
            }
            lis2[l] = nums[i];
            dp[i, 1] = l;
            if (l == s) {
                ++s;
            }
        }
        int ret = 0;
        for (int i = 1; i < n - 1; ++i) {
            if (dp[i, 0] != 0 && dp[i, 1] != 0) {
                ret = Math.Max(ret, 1 + dp[i, 0] + dp[i, 1]);
            }
        }
        return n - ret;
    }
}
// @lc code=end

