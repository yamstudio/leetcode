/*
 * @lc app=leetcode id=1829 lang=java
 *
 * [1829] Maximum XOR for Each Query
 */

// @lc code=start
class Solution {
    public int[] getMaximumXor(int[] nums, int maximumBit) {
        int n = nums.length, xor = 0, target = (1 << maximumBit) - 1;
        int[] ret = new int[n];
        for (int x : nums) {
            xor ^= x;
        }
        for (int i = 0; i < n; ++i) {
            ret[i] = xor ^ target;
            xor ^= nums[n - i - 1];
        }
        return ret;
    }
}
// @lc code=end

