/*
 * @lc app=leetcode id=976 lang=java
 *
 * [976] Largest Perimeter Triangle
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int largestPerimeter(int[] nums) {
        Arrays.sort(nums);
        int n = nums.length;
        for (int i = n - 1; i >= 2; --i) {
            int l = nums[i], m = nums[i - 1], s = nums[i - 2];
            if (m + s > l) {
                return m + s + l;
            }
        }
        return 0;
    }
}
// @lc code=end

