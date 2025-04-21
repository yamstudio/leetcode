/*
 * @lc app=leetcode id=1606 lang=java
 *
 * [1606] Find Servers That Handled Most Number of Requests
 */

import java.util.ArrayList;
import java.util.List;
import java.util.PriorityQueue;
import java.util.Queue;
import java.util.TreeSet;

// @lc code=start
class Solution {
    public List<Integer> busiestServers(int k, int[] arrival, int[] load) {
        TreeSet<Integer> frees = new TreeSet<>();
        Queue<Pair> queue = new PriorityQueue<>(java.util.Comparator.comparingInt(Pair::end).thenComparingInt(Pair::index));
        int[] count = new int[k];
        int n = arrival.length;
        for (int i = 0; i < k; ++i) {
            frees.add(i);
        }
        for (int i = 0; i < n; ++i) {
            int start = arrival[i], end = start + load[i];
            while (!queue.isEmpty() && queue.peek().end() <= start) {
                frees.add(queue.poll().index());
            }
            if (frees.isEmpty()) {
                continue;
            }
            Integer server = frees.ceiling(i % k);
            if (server == null) {
                server = frees.first();
            }
            frees.remove(server);
            ++count[server];
            queue.offer(new Pair(server, end));
        }
        List<Integer> ret = new ArrayList<>();
        int max = 0;
        for (int i = 0; i < k; ++i) {
            if (count[i] > max) {
                max = count[i];
                ret.clear();
                ret.add(i);
            } else if (count[i] == max) {
                ret.add(i);
            }
        }
        return ret;
    }

    private record Pair(int index, int end) {}
}
// @lc code=end

