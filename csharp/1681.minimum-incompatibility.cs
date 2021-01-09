/*
 * @lc app=leetcode id=1681 lang=csharp
 *
 * [1681] Minimum Incompatibility
 */

using System;

// @lc code=start
public class Solution {
    public int MinimumIncompatibility(int[] nums, int k) {
        int n = nums.Length, t = 1 << n, s = n / k;
        int[] sets = new int[t], dp = new int[t];
        for (int mask = 1; mask < t; ++mask) {
            int count = 0, tmp = mask;
            while (tmp != 0) {
                count += tmp & 1;
                tmp >>= 1;
            }
            if (count != s) {
                sets[mask] = -1;
                continue;
            }
            int min = int.MaxValue, max = int.MinValue, seen = 0;
            bool flag = false;
            for (int j = 0; j < n; ++j) {
                if ((mask & (1 << j)) == 0) {
                    continue;
                }
                if ((seen & (1 << nums[j])) != 0) {
                    flag = true;
                    break;
                }
                seen |= 1 << nums[j];
                min = Math.Min(nums[j], min);
                max = Math.Max(nums[j], max);
            }
            if (flag) {
                sets[mask] = -1;
            } else {
                sets[mask] = max - min;
            }
        }
        for (int comb = 1; comb < t; ++comb) {
            int count = 0, tmp = comb;
            while (tmp != 0) {
                count += tmp & 1;
                tmp >>= 1;
            }
            if (count % s != 0) {
                dp[comb] = -1;
                continue;
            }
            dp[comb] = int.MaxValue;
            for (int mask = comb; mask != 0; mask = comb & (mask - 1)) {
                int others = comb ^ mask;
                if (sets[mask] < 0 || dp[others] < 0) {
                    continue;
                }
                dp[comb] = Math.Min(dp[comb], sets[mask] + dp[others]);
            }
            if (dp[comb] == int.MaxValue) {
                dp[comb] = -1;
            }
        }
        return dp[t - 1];
    }
}
// @lc code=end

