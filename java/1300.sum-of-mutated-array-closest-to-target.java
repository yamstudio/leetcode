/*
 * @lc app=leetcode id=1300 lang=java
 *
 * [1300] Sum of Mutated Array Closest to Target
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int findBestValue(int[] arr, int target) {
        Arrays.sort(arr);
        int n = arr.length, i;
        for (i = 0; i < n && target > (n - i) * arr[i]; ++i) {
            target -= arr[i];
        }
        if (i == n) {
            return arr[n - 1];
        }
        int ret = target / (n - i);
        if ((ret + 1) * (n - i) - target < target - ret * (n - i)) {
            ++ret;
        }
        return ret;
    }
}
// @lc code=end

