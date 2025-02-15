/*
 * @lc app=leetcode id=1354 lang=java
 *
 * [1354] Construct Target Array With Multiple Sums
 */

import java.util.PriorityQueue;
import java.util.Queue;

// @lc code=start
class Solution {
    public boolean isPossible(int[] target) {
        int n = target.length, sum = 0;
        if (n == 1) {
            return target[0] == 1;
        }
        Queue<Integer> queue = new PriorityQueue<>(n, java.util.Comparator.reverseOrder());
        for (int num : target) {
            sum += num;
            queue.offer(num);
        }
        while (!queue.isEmpty()) {
            int curr = queue.poll(), otherSum = sum - curr;
            if (otherSum == 1 || curr == 1) {
                return true;
            }
            int prev = curr % otherSum;
            if (prev == 0 || prev == curr) {
                return false;
            }
            queue.offer(prev);
            sum -= (curr - prev);
        }
        return true;
    }
}
// @lc code=end

