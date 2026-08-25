/*
 * @lc app=leetcode id=1802 lang=java
 *
 * [1802] Maximum Value at a Given Index in a Bounded Array
 */

// @lc code=start
class Solution {
    public int maxValue(int n, int index, int maxSum) {
        int l = maxSum / n, r = maxSum - n + 1;
        while (l < r - 1) {
            int m = (l + r) / 2;
            if (minSum(n, m, index) > maxSum) {
                r = m - 1;
            } else {
                l = m;
            }
        }
        return minSum(n, r, index) <= maxSum ? r : l;
    }

    private static long minSum(long n, long x, long index) {
        long ret;
        if (x <= index) {
            ret = (x + 1) * x / 2 + (index + 1 - x);
        } else {
            ret = (x + x - index) * (index + 1) / 2;
        }
        if (x < n - index) {
            ret += (x + 1) * x / 2 + (n - index - x) - x;
        } else {
            ret += (x + x - (n - 1 - index)) * (n - index) / 2 - x;
        }
        return ret;
    }
}
// @lc code=end

