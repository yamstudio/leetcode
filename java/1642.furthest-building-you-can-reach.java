/*
 * @lc app=leetcode id=1642 lang=java
 *
 * [1642] Furthest Building You Can Reach
 */

import java.util.PriorityQueue;
import java.util.Queue;

// @lc code=start

class Solution {
    public int furthestBuilding(int[] heights, int bricks, int ladders) {
        Queue<Integer> queue = new PriorityQueue<>();
        int n = heights.length;
        for (int i = 0; i < n - 1; ++i) {
            if (heights[i] >= heights[i + 1]) {
                continue;
            }

            queue.offer(heights[i + 1] - heights[i]);
            while (queue.size() > ladders) {
                bricks -= queue.poll();
            }
            if (bricks < 0) {
                return i;
            }
        }
        return n - 1;
    }
}
// @lc code=end

