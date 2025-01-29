/*
 * @lc app=leetcode id=1299 lang=java
 *
 * [1299] Replace Elements with Greatest Element on Right Side
 */

// @lc code=start
class Solution {
    public int[] replaceElements(int[] arr) {
        int n = arr.length, rm = -1;
        int[] ret = new int[n];
        for (int i = n - 1; i >= 0; --i) {
            ret[i] = rm;
            rm = Math.max(rm, arr[i]);
        }
        return ret;
    }
}
// @lc code=end

