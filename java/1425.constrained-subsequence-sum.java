/*
 * @lc app=leetcode id=1425 lang=java
 *
 * [1425] Constrained Subsequence Sum
 */

import java.util.ArrayDeque;

// @lc code=start
class Solution {
    public int constrainedSubsetSum(int[] nums, int k) {
        var deque = new ArrayDeque<Pair>();
        int n = nums.length, ret = Integer.MIN_VALUE;
        for (int i = 0; i < n; ++i) {
            while (!deque.isEmpty() && deque.getFirst().i() + k < i) {
                deque.pollFirst();
            }
            int acc = nums[i] + (deque.isEmpty() ? 0 : deque.getFirst().acc());
            ret = Math.max(acc, ret);
            if (acc > 0) {
                while (!deque.isEmpty() && deque.getLast().acc() < acc) {
                    deque.pollLast();
                }
                deque.offerLast(new Pair(i, acc));
            }
        }
        return ret;
    }

    private record Pair(int i, int acc) {}
}
// @lc code=end

