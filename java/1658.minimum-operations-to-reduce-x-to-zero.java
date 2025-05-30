/*
 * @lc app=leetcode id=1658 lang=java
 *
 * [1658] Minimum Operations to Reduce X to Zero
 */

// @lc code=start
class Solution {
    public int minOperations(int[] nums, int x) {
        int n = nums.length, l, acc = 0;
        for (l = 0; l < n && acc < x; ++l) {
            acc += nums[l];
        }
        if (acc < x) {
            return -1;
        }
        int ret = Integer.MAX_VALUE, r = n - 1;
        --l;
        while (l >= 0) {
            if (acc == x) {
                ret = Math.min(ret, l + n - r);
                acc -= nums[l--];
            } else if (acc > x) {
                acc -= nums[l--];
            } else {
                acc += nums[r--];
            }
        }
        while (acc < x) {
            acc += nums[r--];
        }
        if (acc == x) {
            ret = Math.min(ret, n - r - 1);
        }
        return ret == Integer.MAX_VALUE ? -1 : ret;
    }
}
// @lc code=end

