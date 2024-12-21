/*
 * @lc app=leetcode id=1046 lang=java
 *
 * [1046] Last Stone Weight
 */

import java.util.PriorityQueue;

// @lc code=start

import static java.util.Comparator.reverseOrder;

class Solution {
    public int lastStoneWeight(int[] stones) {
        PriorityQueue<Integer> queue = new PriorityQueue<>(reverseOrder());
        for (int s : stones) {
            queue.add(s);
        }
        while (queue.size() > 1) {
            int a = queue.poll(), b = queue.poll();
            if (a == b) {
                continue;
            }
            queue.offer(a - b);
        }
        return queue.isEmpty() ? 0 : queue.poll();
    }
}
// @lc code=end

