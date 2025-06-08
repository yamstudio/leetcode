/*
 * @lc app=leetcode id=1664 lang=java
 *
 * [1664] Ways to Make a Fair Array
 */

// @lc code=start
class Solution {
    public int waysToMakeFair(int[] nums) {
        int n = nums.length;
        if (n == 1) {
            return 1;
        }
        int[][] sums = new int[2][n];
        sums[0][0] = nums[0];
        sums[0][1] = nums[1];
        for (int i = 2; i < n; ++i) {
            sums[0][i] = sums[0][i - 2] + nums[i];
        }
        sums[1][n - 1] = nums[n - 1];
        sums[1][n - 2] = nums[n - 2];
        for (int i = n - 3; i >= 0; --i) {
            sums[1][i] = sums[1][i + 2] + nums[i];
        }
        int ret = 0;
        for (int i = 0; i < n; ++i) {
            int s1 = (i > 0 ? sums[0][i - 1] : 0) + (i + 2 < n ? sums[1][i + 2]  : 0), s2 = (i > 1 ? sums[0][i - 2] : 0) + (i + 1 < n ? sums[1][i + 1] : 0);
            if (s1 == s2) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

