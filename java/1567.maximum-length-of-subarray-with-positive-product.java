/*
 * @lc app=leetcode id=1567 lang=java
 *
 * [1567] Maximum Length of Subarray With Positive Product
 */

// @lc code=start
class Solution {
    public int getMaxLen(int[] nums) {
        int n = nums.length, pos = -1, neg = -1, ret = 0;
        boolean p = true;
        for (int i = 0; i < n; ++i) {
            int x = nums[i];
            if (x == 0) {
                pos = i;
                neg = -1;
                p = true;
                continue;
            }
            if (x < 0) {
                p = !p;
            }
            if (p) {
                ret = Math.max(ret, i - pos);
            } else {
                if (neg >= 0) {
                    ret = Math.max(ret, i - neg);
                } else {
                    neg = i;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

