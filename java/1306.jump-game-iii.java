/*
 * @lc app=leetcode id=1306 lang=java
 *
 * [1306] Jump Game III
 */

import java.util.ArrayDeque;
import java.util.Queue;

// @lc code=start

class Solution {
    public boolean canReach(int[] arr, int start) {
        int n = arr.length;
        boolean[] canReach = new boolean[n];
        Queue<Integer> queue = new ArrayDeque<>();
        canReach[start] = true;
        queue.offer(start);
        while (!queue.isEmpty()) {
            int i = queue.poll(), v = arr[i];
            if (v == 0) {
                return true;
            }
            if (i >= v && !canReach[i - v]) {
                canReach[i - v] = true;
                queue.offer(i - v);
            }
            if (i + v < n && !canReach[i + v]) {
                canReach[i + v] = true;
                queue.offer(i + v);
            }
        }
        return false;
    }
}
// @lc code=end

