/*
 * @lc app=leetcode id=1313 lang=java
 *
 * [1313] Decompress Run-Length Encoded List
 */

// @lc code=start
class Solution {
    public int[] decompressRLElist(int[] nums) {
        int n = nums.length, k = 0, j = 0;
        for (int i = 0; i < n; i += 2) {
            k += nums[i];
        }
        int[] ret = new int[k];
        for (int i = 0; i < n; i += 2) {
            int f = nums[i], v = nums[i + 1];
            while (f-- > 0) {
                ret[j++] = v;
            }
        }
        return ret;
    }
}
// @lc code=end

