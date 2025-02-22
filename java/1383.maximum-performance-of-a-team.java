/*
 * @lc app=leetcode id=1383 lang=java
 *
 * [1383] Maximum Performance of a Team
 */

import java.util.Arrays;
import java.util.PriorityQueue;
import java.util.Queue;

// @lc code=start

class Solution {
    public int maxPerformance(int n, int[] speed, int[] efficiency, int k) {
        Engineer[] engineers = new Engineer[n];
        for (int i = 0; i < n; ++i) {
            engineers[i] = new Engineer(efficiency[i], speed[i]);
        }
        Arrays.sort(engineers, java.util.Comparator.comparingInt(Engineer::efficiency).reversed());
        Queue<Integer> speeds = new PriorityQueue<>(k + 1);
        long ret = 0, sum = 0;
        for (var engineer : engineers) {
            speeds.offer(engineer.speed());
            sum += engineer.speed();
            if (speeds.size() > k) {
                sum -= speeds.poll();
            }
            ret = Math.max(ret, sum * engineer.efficiency());
        }
        return (int)(ret % 1000000007);
    }

    private record Engineer(int efficiency, int speed) {}
}
// @lc code=end

