/*
 * @lc app=leetcode id=689 lang=csharp
 *
 * [689] Maximum Sum of 3 Non-Overlapping Subarrays
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int[] MaxSumOfThreeSubarrays(int[] nums, int k) {
        int n = nums.Length;
        int[] ret = new int[3], sums = new int[n + 1], left = new int[n], right = new int[n];
        for (int i = 0; i < n; ++i) {
            sums[i + 1] = sums[i] + nums[i];
        }
        for (int i = k, sum = sums[k]; i < n; ++i) {
            int curr = sums[i + 1] - sums[i + 1 - k];
            if (curr > sum) {
                left[i] = i + 1 - k;
                sum = curr;
            } else {
                left[i] = left[i - 1];
            }
        }
        right[n - k] = n - k;
        for (int i = n - k - 1, sum = sums[n] - sums[n - k]; i >= 0; --i) {
            int curr = sums[i + k] - sums[i];
            if (curr >= sum) {
                right[i] = i;
                sum = curr;
            } else {
                right[i] = right[i + 1];
            }
        }
        int max = int.MinValue;
        for (int i = k; i <= n - k * 2; ++i) {
            int l = left[i - 1], r = right[i + k], curr = sums[i + k] - sums[i] + sums[l + k] - sums[l] + sums[r + k] - sums[r];
            if (curr > max) {
                ret[0] = l;
                ret[1] = i;
                ret[2] = r;
                max = curr;
            }
        }
        return ret;
    }
}
// @lc code=end

