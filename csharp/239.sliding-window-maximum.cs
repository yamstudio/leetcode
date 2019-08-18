/*
 * @lc app=leetcode id=239 lang=csharp
 *
 * [239] Sliding Window Maximum
 */

using System.Collections.Generic;

public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        if (k == 0) {
            return new int[0];
        }
        int n = nums.Length;
        int[] ret = new int[n - k + 1];
        var deque = new LinkedList<int>();
        for (int i = 0; i < n; ++i) {
            if (deque.Count > 0 && deque.First.Value == i - k) {
                deque.RemoveFirst();
            }
            while (deque.Count > 0 && nums[deque.Last.Value] <= nums[i]) {
                deque.RemoveLast();
            }
            deque.AddLast(i);
            if (i >= k - 1) {
                ret[i - k + 1] = nums[deque.First.Value];
            }
        }
        return ret;
    }
}

