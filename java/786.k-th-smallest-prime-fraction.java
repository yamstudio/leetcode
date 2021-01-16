/*
 * @lc app=leetcode id=786 lang=java
 *
 * [786] K-th Smallest Prime Fraction
 */

// @lc code=start
class Solution {
    public int[] kthSmallestPrimeFraction(int[] arr, int k) {
        int n = arr.length;
        double l = 0.0, r = 1.0;
        while (true) {
            double m = (l + r) / 2.0;
            int count = 0, j = 1, num = 0, denom = 1;
            for (int i = 0; i < n && count <= k; ++i) {
                while (j < n && (double)arr[i] / (double)arr[j] > m) {
                    ++j;
                }
                if (j < n && arr[i] * denom > arr[j] * num) {
                    num = arr[i];
                    denom = arr[j];
                }
                count += n - j;
            }
            if (count < k) {
                l = m;
            } else if (count > k) {
                r = m;
            } else {
                return new int[] { num, denom };
            }
        }
    }
}
// @lc code=end

