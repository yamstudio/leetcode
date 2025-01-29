/*
 * @lc app=leetcode id=1298 lang=java
 *
 * [1298] Maximum Candies You Can Get from Boxes
 */

import java.util.ArrayDeque;
import java.util.HashSet;
import java.util.Queue;
import java.util.Set;

// @lc code=start

class Solution {
    public int maxCandies(int[] status, int[] candies, int[][] keys, int[][] containedBoxes, int[] initialBoxes) {
        Set<Integer> visited = new HashSet<>(), b = new HashSet<>(), k = new HashSet<>();
        Queue<Integer> queue = new ArrayDeque<>();
        int ret = 0;
        for (int box : initialBoxes) {
            b.add(box);
            if (status[box] == 1) {
                queue.offer(box);
            }
        }
        while (!queue.isEmpty()) {
            int curr = queue.poll();
            if (!visited.add(curr)) {
                continue;
            }
            ret += candies[curr];
            for (int cb : containedBoxes[curr]) {
                b.add(cb);
                if ((k.contains(cb) || status[cb] == 1) && !visited.contains(cb)) {
                    queue.offer(cb);
                }
            }
            for (int cb : keys[curr]) {
                k.add(cb);
                if (b.contains(cb) && !visited.contains(cb)) {
                    queue.offer(cb);
                }
            }
        }
        return ret;
    }
}
// @lc code=end

