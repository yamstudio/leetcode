/*
 * @lc app=leetcode id=1589 lang=java
 *
 * [1589] Maximum Sum Obtained of Any Permutation
 */

// @lc code=start

import java.util.Arrays;

class Solution {
    public int maxSumRangeQuery(int[] nums, int[][] requests) {
        int n = nums.length;
        int[] count = new int[n];
        for (int[] r : requests) {
            int start = r[0], end = r[1];
            ++count[start];
            if (end < n - 1) {
                --count[end + 1];
            }
        }
        for (int i = 1; i < n; ++i) {
            count[i] += count[i - 1];
        }
        Arrays.sort(count);
        Arrays.sort(nums);
        int ret = 0;
        for (int i = 0; i < n; ++i) {
            ret = (int)((ret + (((long)nums[i] * (long)count[i]) % 1000000007)) % 1000000007);
        }
        return ret;
    }
}
// @lc code=end

