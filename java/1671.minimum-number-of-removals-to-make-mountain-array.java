/*
 * @lc app=leetcode id=1671 lang=java
 *
 * [1671] Minimum Number of Removals to Make Mountain Array
 */

// @lc code=start
class Solution {
    public int minimumMountainRemovals(int[] nums) {
        int n = nums.length, size = 0;
        int[] llis = new int[n], rlis = new int[n], ldp = new int[n], rdp = new int[n];
        for (int i = 0; i < n; ++i) {
            int l = 0, r = size;
            while (l < r) {
                int m = (l + r) / 2;
                if (llis[m] < nums[i]) {
                    l = m + 1;
                } else {
                    r = m;
                }
            }
            llis[l] = nums[i];
            ldp[i] = l;
            if (l == size) {
                ++size;
            }
        }
        size = 0;
        for (int i = n - 1; i >= 0; --i) {
            int l = 0, r = size;
            while (l < r) {
                int m = (l + r) / 2;
                if (rlis[m] < nums[i]) {
                    l = m + 1;
                } else {
                    r = m;
                }
            }
            rlis[l] = nums[i];
            rdp[i] = l;
            if (l == size) {
                ++size;
            }
        }
        int ret = 0;
        for (int i = 1; i < n - 1; ++i) {
            if (ldp[i] > 0 && rdp[i] > 0) {
                ret = Math.max(ret, 1 + ldp[i] + rdp[i]);
            }
        }
        return n - ret;
    }
}
// @lc code=end

