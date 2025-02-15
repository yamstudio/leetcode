/*
 * @lc app=leetcode id=1353 lang=java
 *
 * [1353] Maximum Number of Events That Can Be Attended
 */

import java.util.Arrays;
import java.util.PriorityQueue;
import java.util.Queue;

// @lc code=start

class Solution {
    public int maxEvents(int[][] events) {
        int n = events.length, i = 0, ret = 0, d = 1;
        Queue<Integer> ends = new PriorityQueue<>();
        Arrays.sort(events, java.util.Comparator.comparing((int[] arr) -> arr[0]));
        while (i < n || !ends.isEmpty()) {
            while (!ends.isEmpty() && ends.peek() < d) {
                ends.poll();
            }
            while (i < n && events[i][0] == d) {
                ends.offer(events[i][1]);
                ++i;
            }
            if (!ends.isEmpty()) {
                ends.poll();
                ++ret;
            }
            ++d;
        }
        return ret;
    }
}
// @lc code=end

