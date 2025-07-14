/*
 * @lc app=leetcode id=1696 lang=java
 *
 * [1696] Jump Game VI
 */

import java.util.ArrayDeque;
import java.util.Deque;

// @lc code=start
class Solution {
    public int maxResult(int[] nums, int k) {
        int n = nums.length;
        Deque<Pair> deque = new ArrayDeque<>(k);
        deque.addLast(new Pair(0, nums[0]));
        for (int i = 1; i < n; ++i) {
            while (!deque.isEmpty() && deque.peekFirst().i() + k < i) {
                deque.removeFirst();
            }
            int s = deque.peekFirst().s() + nums[i];
            while (!deque.isEmpty() && deque.peekLast().s() <= s) {
                deque.removeLast();
            }
            deque.addLast(new Pair(i, s));
        }
        return deque.peekLast().s();
    }

    private record Pair(int i, int s) {}
}
// @lc code=end

