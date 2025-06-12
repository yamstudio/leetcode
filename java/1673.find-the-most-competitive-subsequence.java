/*
 * @lc app=leetcode id=1673 lang=java
 *
 * [1673] Find the Most Competitive Subsequence
 */

// @lc code=start
class Solution {
    public int[] mostCompetitive(int[] nums, int k) {
        int[] ret = new int[k];
        int index = -1, n = nums.length;
        for (int i = 0; i < n; ++i) {
            int x = nums[i];
            while (index >= 0 && ret[index] > x && n - i + index + 1 > k) {
                --index;
            }
            if (index < k - 1) {
                ret[++index] =  x;
            }
        }
        return ret;
    }
}
// @lc code=end

