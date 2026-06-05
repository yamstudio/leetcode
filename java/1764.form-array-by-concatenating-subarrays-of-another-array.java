/*
 * @lc app=leetcode id=1764 lang=java
 *
 * [1764] Form Array by Concatenating Subarrays of Another Array
 */

// @lc code=start
class Solution {
    public boolean canChoose(int[][] groups, int[] nums) {
        int n = nums.length, i = 0, m = 0;
        for (int[] g : groups) {
            int k = g.length;
            for (; i + k <= n; ++i) {
                int d;
                for (d = 0; d < k && g[d] == nums[i + d]; ++d);
                if (d == k) {
                    i += k;
                    ++m;
                    break;
                }
            }
        }
        return m == groups.length;
    }
}
// @lc code=end

