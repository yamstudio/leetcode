/*
 * @lc app=leetcode id=967 lang=java
 *
 * [967] Numbers With Same Consecutive Differences
 */

import java.util.ArrayDeque;
import java.util.HashSet;
import java.util.Queue;
import java.util.Set;

// @lc code=start

class Solution {
    public int[] numsSameConsecDiff(int n, int k) {
        Queue<Integer> queue = new ArrayDeque<>();
        queue.offer(1);
        queue.offer(2);
        queue.offer(3);
        queue.offer(4);
        queue.offer(5);
        queue.offer(6);
        queue.offer(7);
        queue.offer(8);
        queue.offer(9);
        int tar = ((Double) Math.pow(10, n - 1)).intValue();
        Set<Integer> ret = new HashSet<>();
        while (!queue.isEmpty()) {
            int i = queue.poll();
            if (i >= tar) {
                ret.add(i);
                continue;
            } 
            int l = i % 10;
            if (l + k <= 9) {
                queue.offer(i * 10 + l + k);
            }
            if (l - k >= 0) {
                queue.offer(i * 10 + l - k);
            }
        }
        return ret.stream().mapToInt(Integer::intValue).toArray();
    }
}
// @lc code=end

