/*
 * @lc app=leetcode id=1343 lang=java
 *
 * [1343] Number of Sub-arrays of Size K and Average Greater than or Equal to Threshold
 */

// @lc code=start
class Solution {
    public int numOfSubarrays(int[] arr, int k, int threshold) {
        int n = arr.length, ret = 0, acc = 0;
        for (int r = 0; r < n; ++r) {
            acc += arr[r];
            if (r < k - 1) {
                continue;
            }
            if (r >= k) {
                acc -= arr[r - k];
            }
            if (acc >= threshold * k) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

