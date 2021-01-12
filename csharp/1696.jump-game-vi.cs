/*
 * @lc app=leetcode id=1696 lang=csharp
 *
 * [1696] Jump Game VI
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int MaxResult(int[] nums, int k) {
        var deque = new LinkedList<(int Index, int Value)>();
        int n = nums.Length;
        deque.AddFirst((Index: 0, Value: nums[0]));
        for (int i = 1; i < n; ++i) {
            while (deque.First.Value.Index < i - k) {
                deque.RemoveFirst();
            }
            int val = deque.First.Value.Value + nums[i];
            while (deque.Count > 0 && deque.Last.Value.Value <= val) {
                deque.RemoveLast();
            }
            deque.AddLast((Index: i, Value: val));
        }
        return deque.Last.Value.Value;
    }
}
// @lc code=end

