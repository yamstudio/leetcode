/*
 * @lc app=leetcode id=978 lang=java
 *
 * [978] Longest Turbulent Subarray
 */

// @lc code=start
class Solution {
    public int maxTurbulenceSize(int[] arr) {
        int ret = 1, n = arr.length, p = 0, curr = 1;
        for (int i = 1; i < n; ++i) {
            int c = arr[i] - arr[i - 1];
            if (c == 0) {
                curr = 1;
            } else if (c > 0) {
                if (p < 0) {
                    ++curr;
                } else {
                    curr = 2;
                }
            } else {
                if (p > 0) {
                    ++curr;
                } else {
                    curr = 2;
                }
            }
            p = c;
            ret = Math.max(ret, curr);
        }
        return ret;
    }
}
// @lc code=end

