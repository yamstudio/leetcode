/*
 * @lc app=leetcode id=312 lang=csharp
 *
 * [312] Burst Balloons
 */

using System;

public class Solution {
    public int MaxCoins(int[] nums) {
        int n = nums.Length;
        Func<int, int> ballons = x => (x >= 1 && x <= n) ? nums[x - 1] : 1;
        int[,] dp = new int[n + 2, n + 2];
        for (int len = 1; len <= n; ++len) {
            for (int left = 1; left <= n - len + 1; ++left) {
                int right = left + len - 1, r = 0, sides = ballons(left - 1) * ballons(right + 1);
                for (int burst = left; burst <= right; ++burst) {
                    r = Math.Max(r, ballons(burst) * sides + dp[left, burst - 1] + dp[burst + 1, right]);
                }
                dp[left, right] = r;
            }
        }
        return dp[1, n];
    }
}

