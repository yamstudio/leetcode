/*
 * @lc app=leetcode id=1031 lang=java
 *
 * [1031] Maximum Sum of Two Non-Overlapping Subarrays
 */

// @lc code=start
class Solution {
    public int maxSumTwoNoOverlap(int[] nums, int firstLen, int secondLen) {
        int n = nums.length;
        int[] prefixSum = new int[n];
        prefixSum[0] = nums[0];
        for (int i = 1; i < n; ++i) {
            prefixSum[i] = nums[i] + prefixSum[i - 1];
        }
        int ret = prefixSum[firstLen + secondLen - 1], firstMax = prefixSum[firstLen - 1], secondMax = prefixSum[secondLen - 1];
        for (int i = firstLen + secondLen; i < n; ++i) {
            firstMax = Math.max(firstMax, prefixSum[i - secondLen] - prefixSum[i - secondLen - firstLen]);
            secondMax = Math.max(secondMax, prefixSum[i - firstLen] - prefixSum[i - firstLen - secondLen]);
            ret = Math.max(ret, Math.max(firstMax + prefixSum[i] - prefixSum[i -  secondLen], secondMax + prefixSum[i] - prefixSum[i - firstLen]));
        }
        return ret;
    }
}
// @lc code=end

