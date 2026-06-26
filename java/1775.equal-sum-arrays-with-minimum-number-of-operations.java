/*
 * @lc app=leetcode id=1775 lang=java
 *
 * [1775] Equal Sum Arrays With Minimum Number of Operations
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int minOperations(int[] nums1, int[] nums2) {
        int l1 = nums1.length, l2 = nums2.length;
        if (l1 * 6 < l2 || l2 * 6 < l1) {
            return -1;
        }
        int sum1 = Arrays.stream(nums1).sum(), sum2 = Arrays.stream(nums2).sum();
        return sum1 < sum2 ? minOperations(nums1, sum1, nums2, sum2) : minOperations(nums2, sum2, nums1, sum1);
    }

    private static int minOperations(int[] nums1, int sum1, int[] nums2, int sum2) {
        int[] count1 = new int[6], count2 = new int[6];
        for (int x : nums1) {
            ++count1[x - 1];
        }
        for (int x : nums2) {
            ++count2[x - 1];
        }
        int diff = sum2 - sum1, ret = 0;
        for (int x = 5; x >= 0 && diff > 0; --x) {
            int change = Math.min(
                count1[5 - x] + count2[x],
                diff / x + (diff % x > 0 ? 1 : 0)
            );
            diff -= change * x;
            ret += change;
        }
        return ret;
    }
}
// @lc code=end

