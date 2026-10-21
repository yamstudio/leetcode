/*
 * @lc app=leetcode id=1834 lang=java
 *
 * [1834] Single-Threaded CPU
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.PriorityQueue;
import java.util.Queue;


// @lc code=start
import static java.util.Comparator.comparingInt;

class Solution {
    public int[] getOrder(int[][] tasks) {
        int t, n = tasks.length;
        int[] ret = new int[n];
        List<Task> sorted = new ArrayList<>(n);
        for (int i = 0; i < n; ++i) {
            int[] task = tasks[i];
            sorted.add(new Task(task[0], task[1], i));
        }
        Collections.sort(sorted, comparingInt(Task::enqueueTime));
        Queue<Task> queue = new PriorityQueue<>(n, comparingInt(Task::processingTime).thenComparingInt(Task::index));
        t = sorted.get(0).enqueueTime();
        for (int i = 0, r = 0; r < n; ++r) {
            if (i < n) {
                if (queue.isEmpty() && t < sorted.get(i).enqueueTime()) {
                    t = sorted.get(i).enqueueTime();
                }
                while (i < n && sorted.get(i).enqueueTime() <= t) {
                    queue.offer(sorted.get(i));
                    ++i;
                }
            }
            Task task = queue.poll();
            ret[r] = task.index();
            t += task.processingTime();
        }
        return ret;
    }

    private record Task(int enqueueTime, int processingTime, int index) {}
}
// @lc code=end

