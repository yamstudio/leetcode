/*
 * @lc app=leetcode id=1403 lang=java
 *
 * [1403] Minimum Subsequence in Non-Increasing Order
 */

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

// @lc code=start
class Solution {
    public List<Integer> minSubsequence(int[] nums) {
        int n = nums.length, target = 0;
        for (int num : nums) {
            target += num;
        }
        target /= 2;
        Arrays.sort(nums);
        List<Integer> ret = new ArrayList<>();
        for (int i = n - 1; i >= 0 && target >= 0; --i) {
            ret.add(nums[i]);
            target -= nums[i];
        }
        return ret;
    }
}
// @lc code=end

