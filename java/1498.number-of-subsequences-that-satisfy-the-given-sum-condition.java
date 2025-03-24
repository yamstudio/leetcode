/*
 * @lc app=leetcode id=1498 lang=java
 *
 * [1498] Number of Subsequences That Satisfy the Given Sum Condition
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int numSubseq(int[] nums, int target) {
        int n = nums.length, ret = 0, l = 0, r = n - 1;
        int[] pow = new int[n];
        Arrays.sort(nums);
        pow[0] = 1;
        for (int i = 1; i < n; ++i) {
            pow[i] = (2 * pow[i - 1]) % 1000000007;
        }
        while (l <= r) {
            if (nums[l] + nums[r] > target) {
                --r;
            } else {
                ret = (ret + pow[r - l]) % 1000000007;
                ++l;
            }
        }
        return ret;
    }
}
// @lc code=end

