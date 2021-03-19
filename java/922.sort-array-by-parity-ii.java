/*
 * @lc app=leetcode id=922 lang=java
 *
 * [922] Sort Array By Parity II
 */

// @lc code=start
class Solution {
    public int[] sortArrayByParityII(int[] nums) {
        int n = nums.length;
        for (int i = 0, j = 1; i < n && j < n;) {
            if (nums[i] % 2 == 0) {
                i += 2;
            } else if (nums[j] % 2 == 1) {
                j += 2;
            } else {
                int t = nums[i];
                nums[i] = nums[j];
                nums[j] = t;
                i += 2;
                j += 2;
            }
        }
        return nums;
    }
}
// @lc code=end

