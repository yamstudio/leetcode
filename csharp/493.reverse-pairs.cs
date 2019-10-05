/*
 * @lc app=leetcode id=493 lang=csharp
 *
 * [493] Reverse Pairs
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int ReversePairsRecurse(List<int> nums, int start, int end) {
        if (start >= end) {
            return 0;
        }
        int mid = start + (end - start) / 2, ret = ReversePairsRecurse(nums, start, mid) + ReversePairsRecurse(nums, mid + 1, end);
        int right = mid + 1;
        for (int i = start; i <= mid; ++i) {
            long curr = (long) nums[i];
            while (right <= end && curr > 2 * (long) nums[right]) {
                ++right;
            }
            ret += right - mid - 1;
        }
        nums.Sort(start, end - start + 1, Comparer<int>.Default);
        return ret;
    }

    public int ReversePairs(int[] nums) {
        return ReversePairsRecurse(new List<int>(nums), 0, nums.Length - 1);
    }
}
// @lc code=end

