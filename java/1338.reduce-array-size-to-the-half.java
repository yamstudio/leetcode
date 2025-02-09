/*
 * @lc app=leetcode id=1338 lang=java
 *
 * [1338] Reduce Array Size to The Half
 */
import java.util.Queue;
import java.util.HashMap;
import java.util.Map;
import java.util.PriorityQueue;

// @lc code=start

import static java.util.Comparator.reverseOrder;;

class Solution {
    public int minSetSize(int[] arr) {
        int n = arr.length;
        Map<Integer, Integer> count = new HashMap<>();
        for (int num : arr) {
            count.put(num, count.getOrDefault(num, 0) + 1);
        }
        Queue<Integer> queue = new PriorityQueue<>(count.size(), reverseOrder());
        queue.addAll(count.values());
        int acc = 0;
        while (acc * 2 < n) {
            acc += queue.poll();
        }
        return count.size() - queue.size();
    }
}
// @lc code=end

