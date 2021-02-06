/*
 * @lc app=leetcode id=845 lang=java
 *
 * [845] Longest Mountain in Array
 */

// @lc code=start
class Solution {
    public int longestMountain(int[] arr) {
        int ret = 0, l = 0, p = 0, n = arr.length;
        for (int i = 1; i < n; ++i) {
            if (arr[i] > arr[i - 1]) {
                if (p < i - 1) {
                    l = i - 1;
                }
                p = i;
            } else if (arr[i] < arr[i - 1] && p != l) {
                ret = Math.max(i - l + 1, ret);
            } else {
                l = i;
                p = i;
            }
        }
        return ret;
    }
}
// @lc code=end

