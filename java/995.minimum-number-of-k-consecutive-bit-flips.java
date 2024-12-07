/*
 * @lc app=leetcode id=995 lang=java
 *
 * [995] Minimum Number of K Consecutive Bit Flips
 */

// @lc code=start
class Solution {
    public int minKBitFlips(int[] nums, int k) {
        int n = nums.length, flippedAcc = 0, ret = 0;
        int[] flipped = new int[n];
        for (int i = 0; i < n; ++i) {
            if (i >= k) {
                flippedAcc ^= flipped[i - k];
            }
            if (flippedAcc != nums[i]) {
                continue;
            }
            if (i + k > n) {
                return -1;
            }
            ++ret;
            flipped[i] = 1;
            flippedAcc ^= 1;
        }
        return ret;
    }
}
// @lc code=end

