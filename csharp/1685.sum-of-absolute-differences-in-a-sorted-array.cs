/*
 * @lc app=leetcode id=1685 lang=csharp
 *
 * [1685] Sum of Absolute Differences in a Sorted Array
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int[] GetSumAbsoluteDifferences(int[] nums) {
        int n = nums.Length, sum = nums.Sum(), acc = 0;
        int[] ret = new int[n];
        for (int i = 0; i < n ; ++i) {
            ret[i] = sum - 2 * acc + nums[i] * (2 * i - n);
            acc += nums[i];
        }
        return ret;
    }
}
// @lc code=end

