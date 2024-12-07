/*
 * @lc app=leetcode id=992 lang=java
 *
 * [992] Subarrays with K Different Integers
 */

// @lc code=start
class Solution {
    public int subarraysWithKDistinct(int[] nums, int k) {
        return subarraysWithKOrLess(nums, k) - subarraysWithKOrLess(nums, k - 1);
    }

    private static int subarraysWithKOrLess(int[] nums, int k) {
        int n = nums.length, l = 0, acc = 0, ret = 0;
        if (k == 0) {
            return 0;
        }
        int[] count = new int[n + 1];
        for (int r = 0; r < n; ++r) {
            int num = nums[r];
            if (count[num] == 0) {
                ++acc;
            }
            ++count[num];
            while (acc > k) {
                int d = nums[l];
                if (count[d] == 1) {
                    --acc;
                }
                --count[d];
                ++l;
            }
            ret += r - l + 1;
        }
        return ret;
    }
}
// @lc code=end

