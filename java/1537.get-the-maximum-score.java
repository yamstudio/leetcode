/*
 * @lc app=leetcode id=1537 lang=java
 *
 * [1537] Get the Maximum Score
 */

// @lc code=start
class Solution {
    public int maxSum(int[] nums1, int[] nums2) {
        int l1 = nums1.length, l2 = nums2.length, i1 = 0, i2 = 0;
        long ret = 0, acc1 = 0, acc2 = 0;
        while (i1 < l1 && i2 < l2) {
            int c1 = nums1[i1], c2 = nums2[i2];
            if (c1 < c2) {
                acc1 += c1;
                ++i1;
            } else if (c1 > c2) {
                acc2 += c2;
                ++i2;
            } else {
                ret += Math.max(acc1, acc2);
                acc1 = c1;
                acc2 = c2;
                ++i1;
                ++i2;
            }
        }
        while (i1 < l1) {
            acc1 += nums1[i1++];
        }
        while (i2 < l2) {
            acc2 += nums2[i2++];
        }
        return (int)((ret + Math.max(acc1, acc2)) % 1000000007);
    }
}
// @lc code=end

