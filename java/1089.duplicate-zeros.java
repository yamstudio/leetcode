/*
 * @lc app=leetcode id=1089 lang=java
 *
 * [1089] Duplicate Zeros
 */

import java.util.ArrayDeque;
import java.util.Queue;

// @lc code=start

class Solution {
    public void duplicateZeros(int[] arr) {
        int n = arr.length;
        Queue<Integer> queue = new ArrayDeque<>(n);
        boolean dup = false;
        for (int i = 0; i < n; ++i) {
            queue.offer(arr[i]);
            if (dup) {
                dup = false;
                arr[i] = 0;
                continue;
            }
            int x = queue.poll();
            dup = x == 0;
            arr[i] = x;
        }
    }
}
// @lc code=end

