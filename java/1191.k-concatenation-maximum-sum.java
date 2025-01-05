/*
 * @lc app=leetcode id=1191 lang=java
 *
 * [1191] K-Concatenation Maximum Sum
 */

// @lc code=start
class Solution {
    public int kConcatenationMaxSum(int[] arr, int k) {
        long lm = 0, lacc = 0, rm = 0, racc = 0, tm = 0, tacc = 0;
        int n = arr.length;
        for (int i = 0; i < n; ++i) {
            lacc += arr[i];
            lm = Math.max(lm, lacc);
            racc += arr[n - 1 - i];
            rm = Math.max(rm, racc);
            tacc = Math.max(0, tacc) + arr[i];
            tm = Math.max(tm, tacc);
        }
        if (k == 1) {
            return (int)(tm % 1000000007);
        }
        return (int)(Math.max(tm, Math.max(0, (k - 2) * lacc) + lm + rm) % 1000000007);
    }
}
// @lc code=end

