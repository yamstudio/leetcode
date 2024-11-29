/*
 * @lc app=leetcode id=962 lang=java
 *
 * [962] Maximum Width Ramp
 */

import java.util.Stack;

// @lc code=start

class Solution {
    public int maxWidthRamp(int[] nums) {
        var stack = new Stack<Integer>();
        int ret = 0, n = nums.length;
        for (int i = 0; i < n; ++i) {
            if (stack.isEmpty() || nums[stack.peek()] > nums[i]) {
                stack.push(i);
            }
        }
        for (int i = n - 1; i > 0 && !stack.isEmpty(); --i) {
            int curr = nums[i];
            while (!stack.isEmpty() && nums[stack.peek()] <= curr) {
                ret = Math.max(ret, i - stack.pop());
            }
        }
        return ret;
    }
}
// @lc code=end

