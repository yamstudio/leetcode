/*
 * @lc app=leetcode id=1425 lang=csharp
 *
 * [1425] Constrained Subsequence Sum
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int ConstrainedSubsetSum(int[] nums, int k) {
        var deque = new LinkedList<(int Index, int Sum)>();
        int ret = int.MinValue;
        int n = nums.Length;
        for (int i = 0; i < n; ++i) {
            while (deque.Count > 0 && deque.First.Value.Index + k < i) {
                deque.RemoveFirst();
            }
            int curr = nums[i] + (deque.Count > 0 ? deque.First.Value.Sum : 0);
            ret = Math.Max(ret, curr);
            if (curr > 0) {
                while (deque.Count > 0 && deque.Last.Value.Sum < curr) {
                    deque.RemoveLast();
                }
                deque.AddLast((Index: i, Sum: curr));
            }
        }
        return ret;
    }
}
// @lc code=end

