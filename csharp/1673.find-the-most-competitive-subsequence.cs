/*
 * @lc app=leetcode id=1673 lang=csharp
 *
 * [1673] Find the Most Competitive Subsequence
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int[] MostCompetitive(int[] nums, int k) {
        int n = nums.Length;
        var stack = new Stack<int>();
        for (int i = 0; i < n; ++i) {
            int curr = nums[i];
            while (stack.TryPeek(out var p) && p > curr && n - i + stack.Count > k) {
                stack.Pop();
            }
            if (stack.Count < k) {
                stack.Push(curr);
            }
        }
        return stack.Reverse().ToArray();
    }
}
// @lc code=end

