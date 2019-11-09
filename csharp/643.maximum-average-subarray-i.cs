/*
 * @lc app=leetcode id=643 lang=csharp
 *
 * [643] Maximum Average Subarray I
 */

using System.Linq;

// @lc code=start
public class Solution {
    public double FindMaxAverage(int[] nums, int k) {
        int ret = nums.Take(k).Sum(), n = nums.Length, sum = ret;
        for (int i = k; i < n; ++i) {
            sum += nums[i] - nums[i - k];
            ret = Math.Max(sum, ret);
        }
        return (double) ret / (double) k;
    }
}
// @lc code=end

