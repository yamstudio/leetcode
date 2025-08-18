/*
 * @lc app=leetcode id=1712 lang=java
 *
 * [1712] Ways to Split Array Into Three Subarrays
 */

// @lc code=start
class Solution {
    public int waysToSplit(int[] nums) {
        int n = nums.length, ret = 0;
        int[] sums = new int[n];
        sums[0] = nums[0];
        for (int i = 1; i < n; ++i) {
            sums[i] = nums[i] + sums[i - 1];
        }
        for (int i = 1; i < n - 1; ++i) {
            int ls = sums[i - 1];
            if (ls * 2 > sums[n - 1] - ls) {
                break;
            }
            int l = findLeft(sums, ls, i);
            if (l < 0) {
                continue;
            }
            int r = findRight(sums, ls, i);
            ret = (ret + (r - l + 1)) % 1000000007;
        }
        return ret;
    }

    private static int findLeft(int[] sums, int ls, int li) {
        int l = li, r = sums.length - 2, n = sums.length, ret = -1;
        while (l <= r) {
            int m = (l + r) / 2, ms = sums[m] - ls, rs = sums[n - 1] - sums[m];
            if (ls <= ms && ms <= rs) {
                r = m - 1;
                ret = m;
            } else if (ls > ms) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }
        return ret;
    }

    private static int findRight(int[] sums, int ls, int li) {
        int l = li, r = sums.length - 2, n = sums.length, ret = -1;
        while (l <= r) {
            int m = (l + r) / 2, ms = sums[m] - ls, rs = sums[n - 1] - sums[m];
            if (ls <= ms && ms <= rs) {
                l = m + 1;
                ret = m;
            } else if (ls > ms) {
                l = m + 1;
            } else {
                r = m - 1;
            }
        }
        return ret;
    }
}
// @lc code=end

