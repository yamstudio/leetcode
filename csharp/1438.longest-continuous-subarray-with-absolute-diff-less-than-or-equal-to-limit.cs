/*
 * @lc app=leetcode id=1438 lang=csharp
 *
 * [1438] Longest Continuous Subarray With Absolute Diff Less Than or Equal to Limit
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int LongestSubarray(int[] nums, int limit) {
        var minDeque = new LinkedList<int>();
        var maxDeque = new LinkedList<int>();
        int n = nums.Length, l = 0, ret = 0;
        for (int r = 0; r < n; ++r) {
            int curr = nums[r];
            while (minDeque.Count > 0 && nums[minDeque.Last.Value] >= curr) {
                minDeque.RemoveLast();
            }
            minDeque.AddLast(r);
            while (maxDeque.Count > 0 && nums[maxDeque.Last.Value] <= curr) {
                maxDeque.RemoveLast();
            }
            maxDeque.AddLast(r);
            while (nums[maxDeque.First.Value] - nums[minDeque.First.Value] > limit) {
                if (maxDeque.First.Value == l) {
                    maxDeque.RemoveFirst();
                }
                if (minDeque.First.Value == l) {
                    minDeque.RemoveFirst();
                }
                ++l;
            }
            ret = Math.Max(ret, r - l + 1);
        }
        return ret;
    }
}
// @lc code=end

