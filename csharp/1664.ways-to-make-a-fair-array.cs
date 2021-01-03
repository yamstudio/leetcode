/*
 * @lc app=leetcode id=1664 lang=csharp
 *
 * [1664] Ways to Make a Fair Array
 */

// @lc code=start
public class Solution {
    public int WaysToMakeFair(int[] nums) {
        int n = nums.Length;
        if (n == 1) {
            return 1;
        }
        int[,] sums = new int[n, 2];
        sums[0, 0] = nums[0];
        sums[1, 0] = nums[1];
        for (int i = 2; i < n; ++i) {
            sums[i, 0] = sums[i - 2, 0] + nums[i];
        }
        sums[n - 1, 1] = nums[n - 1];
        sums[n - 2, 1] = nums[n - 2];
        for (int i = n - 3; i >= 0; --i) {
            sums[i, 1] = sums[i + 2, 1] + nums[i];
        }
        int ret = 0;
        for (int i = 0; i < n; ++i) {
            int p = (i > 0 ? sums[i - 1, 0] : 0) + (i + 2 < n ? sums[i + 2, 1] : 0), pp = (i > 1 ? sums[i - 2, 0] : 0) + (i + 1 < n ? sums[i + 1, 1] : 0);
            if (p == pp) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

