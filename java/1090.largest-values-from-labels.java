/*
 * @lc app=leetcode id=1090 lang=java
 *
 * [1090] Largest Values From Labels
 */

import java.util.HashMap;
import java.util.Map;
import java.util.PriorityQueue;
import java.util.Queue;

// @lc code=start

import static java.util.Comparator.comparing;

class Solution {
    public int largestValsFromLabels(int[] values, int[] labels, int numWanted, int useLimit) {
        Map<Integer, Integer> count = new HashMap<>();
        int n = values.length;
        Queue<Pair> queue = new PriorityQueue<>(comparing(Pair::value).reversed());
        for (int i = 0; i < n; ++i) {
            queue.offer(new Pair(values[i], labels[i]));
        }
        int ret = 0;
        while (numWanted > 0 && !queue.isEmpty()) {
            Pair p = queue.poll();
            int used = count.getOrDefault(p.label(), 0);
            if (used == useLimit) {
                continue;
            }
            --numWanted;
            count.put(p.label(), used + 1);
            ret += p.value();
        }
        return ret;
    }

    private record Pair(int value, int label) {}
}
// @lc code=end

