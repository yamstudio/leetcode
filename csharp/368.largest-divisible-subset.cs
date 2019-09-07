/*
 * @lc app=leetcode id=368 lang=csharp
 *
 * [368] Largest Divisible Subset
 */

using System;

public class Solution {
    public IList<int> LargestDivisibleSubset(int[] nums) {
        int n = nums.Length, max = 0, mi = 0;
        int[] dp = new int[n], parent = new int[n];
        Array.Sort(nums);
        for (int i = n - 1; i >= 0; --i) {
            int curr = nums[i];
            for (int j = i; j < n; ++j) {
                if (nums[j] % curr == 0 && dp[i] <= dp[j]) {
                    dp[i] = dp[j] + 1;
                    parent[i] = j;
                    if (max < dp[i]) {
                        max = dp[i];
                        mi = i;
                    }
                }
            }
        }
        var ret = new List<int>(max);
        while (max-- > 0) {
            ret.Add(nums[mi]);
            mi = parent[mi];
        }
        return ret;
    }
}

