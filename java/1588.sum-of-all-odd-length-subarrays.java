/*
 * @lc app=leetcode id=1588 lang=java
 *
 * [1588] Sum of All Odd Length Subarrays
 */

// @lc code=start
class Solution {
    public int sumOddLengthSubarrays(int[] arr) {
        int n = arr.length, ret = 0;
        for (int i = 0; i < n; ++i) {
            ret += ((i + 1) * (n - i) + 1) / 2 * arr[i];
        }
        return ret;
    }
}
// @lc code=end

