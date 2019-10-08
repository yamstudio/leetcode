/*
 * @lc app=leetcode id=503 lang=csharp
 *
 * [503] Next Greater Element II
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int[] NextGreaterElements(int[] nums) {
        int n = nums.Length, m = 2 * n;
        IList<int> stack = new List<int>();
        int[] ret = new int[n];
        for (int i = 0; i < m; ++i) {
            int num;
            if (i < n) {
                ret[i] = -1;
                num = nums[i];
            } else {
                num = nums[i - n];
            }
            while (stack.Count > 0 && nums[stack[stack.Count - 1]] < num) {
                ret[stack[stack.Count - 1]] = num;
                stack.RemoveAt(stack.Count - 1);
            }
            if (i < n) {
                stack.Add(i);
            }
        }
        return ret;
    }
}
// @lc code=end

