/*
 * @lc app=leetcode id=1574 lang=java
 *
 * [1574] Shortest Subarray to be Removed to Make Array Sorted
 */

// @lc code=start
class Solution {
    public int findLengthOfShortestSubarray(int[] arr) {
        int l, n = arr.length;
        for (l = 0; l + 1 < n && arr[l] <= arr[l + 1]; ++l) {}
        if (l == n - 1) {
            return 0;
        }
        int r;
        for (r = n - 1; r > l && arr[r] >= arr[r - 1]; --r) {}
        int ret = Math.min(n - 1 - l, r), i = 0;
        while (i <= l && r < n) {
            if (arr[i] <= arr[r]) {
                ret = Math.min(ret, r - i - 1);
                ++i;
            } else {
                ++r;
            }
        }
        return ret;
    }
}
// @lc code=end

