/*
 * @lc app=leetcode id=1619 lang=java
 *
 * [1619] Mean of Array After Removing Some Elements
 */

import java.util.PriorityQueue;
import java.util.Queue;

// @lc code=start

class Solution {
    public double trimMean(int[] arr) {
        double sum = 0;
        int n = arr.length, t = n / 20;
        Queue<Integer> min = new PriorityQueue<>(t + 1), max = new PriorityQueue<>(t + 1, java.util.Comparator.reverseOrder());
        for (int i = 0; i < t; ++i) {
            int x = arr[i];
            sum += x;
            min.offer(x);
            max.offer(x);
        }
        for (int i = t; i < n; ++i) {
            int x = arr[i];
            sum += x;
            min.offer(x);
            max.offer(x);
            min.poll();
            max.poll();
        }
        for (int i = 0; i < t; ++i) {
            sum -= min.poll() + max.poll();
        }
        return sum / (n - t - t);
    }
}
// @lc code=end

