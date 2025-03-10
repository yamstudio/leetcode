/*
 * @lc app=leetcode id=1438 lang=java
 *
 * [1438] Longest Continuous Subarray With Absolute Diff Less Than or Equal to Limit
 */

import java.util.ArrayDeque;
// @lc code=start
class Solution {
    public int longestSubarray(int[] nums, int limit) {
        ArrayDeque<Integer> max = new ArrayDeque<>(), min = new ArrayDeque<>();
        int n = nums.length, ret = 0, l = 0;
        for (int r = 0; r < n; ++r) {
            int num = nums[r];
            while (!max.isEmpty() && nums[max.getLast()] <= num) {
                max.removeLast();
            }
            max.addLast(r);
            while (!min.isEmpty() && nums[min.getLast()] >= num) {
                min.removeLast();
            }
            min.addLast(r);
            while (nums[max.getFirst()] - nums[min.getFirst()] > limit) {
                if (max.getFirst() == l) {
                    max.removeFirst();
                }
                if (min.getFirst() == l) {
                    min.removeFirst();
                }
                ++l;
            }
            ret = Math.max(ret, r - l + 1);
        }
        return ret;
    }
}
// @lc code=end

