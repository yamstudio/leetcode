/*
 * @lc app=leetcode id=1499 lang=java
 *
 * [1499] Max Value of Equation
 */

import java.util.ArrayDeque;
import java.util.Deque;

// @lc code=start
class Solution {
    public int findMaxValueOfEquation(int[][] points, int k) {
        Deque<int[]> deque = new ArrayDeque<>();
        int ret = Integer.MIN_VALUE;
        for (int[] point : points) {
            while (!deque.isEmpty() && deque.getFirst()[0] < point[0] - k) {
                deque.removeFirst();
            }
            if (!deque.isEmpty()) {
                ret = Math.max(ret, point[1] + deque.getFirst()[1] + point[0] - deque.getFirst()[0]);
            }
            int diff = point[1] - point[0];
            while (!deque.isEmpty() && deque.getLast()[1] - deque.getLast()[0] < diff) {
                deque.removeLast();
            }
            deque.addLast(point);
        }
        return ret;
    }
}
// @lc code=end

