/*
 * @lc app=leetcode id=713 lang=csharp
 *
 * [713] Subarray Product Less Than K
 */

// @lc code=start
public class Solution {
    public int NumSubarrayProductLessThanK(int[] nums, int k) {
        if (k <= 1) {
            return 0;
        }
        int ret = 0, prod = 1, i = 0, n = nums.Length;
        for (int j = 0; j < n; ++j) {
            prod *= nums[j];
            while (prod >= k) {
                prod /= nums[i];
                ++i;
            }
            ret += j - i + 1;
        }
        return ret;
    }
}
// @lc code=end

