/*
 * @lc app=leetcode id=977 lang=java
 *
 * [977] Squares of a Sorted Array
 */

// @lc code=start
class Solution {
    public int[] sortedSquares(int[] nums) {
        int n = nums.length, r = findNonNegIndex(nums), l = r - 1;
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            if (l < 0 || (r < n && -nums[l] > nums[r])) {
                ret[i] = nums[r] * nums[r];
                ++r; 
            } else {
                ret[i] = nums[l] * nums[l];
                --l;
            }
        }
        return ret;
    }

    private static int findNonNegIndex(int[] nums) {
        int n = nums.length, l = 0, r = n - 1;
        while (l < r) {
            int m = (l + r) / 2;
            if (nums[m] >= 0) {
                r = m;
            } else {
                l = m + 1;
            }
        }
        return l;
    }
}
// @lc code=end

