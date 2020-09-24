/*
 * @lc app=leetcode id=1248 lang=csharp
 *
 * [1248] Count Number of Nice Subarrays
 */

// @lc code=start
public class Solution {
    public int NumberOfSubarrays(int[] nums, int k) {
        int n = nums.Length, l = 0, llen = 0, ret = 0;
        for (int r = 0; r < n; ++r) {
            if (nums[r] % 2 == 1) {
                --k;
                llen = 0;
            }
            while (k == 0) {
                k += nums[l++] % 2;
                ++llen;
            }
            ret += llen;
        }
        return ret;
    }
}
// @lc code=end

