/*
 * @lc app=leetcode id=1524 lang=java
 *
 * [1524] Number of Sub-arrays With Odd Sum
 */

// @lc code=start
class Solution {
    public int numOfSubarrays(int[] arr) {
        int acc = 0, ret = 0, odds = 0, n = arr.length;
        for (int i = 0; i < n; ++i) {
            acc ^= (arr[i] & 1);
            ret = (ret + odds * (1 - acc) + (1 + i - odds) * acc) % 1000000007;
            odds += acc;
        }
        return ret;
    }
}
// @lc code=end

