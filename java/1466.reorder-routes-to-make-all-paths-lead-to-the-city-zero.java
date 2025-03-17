/*
 * @lc app=leetcode id=1466 lang=java
 *
 * [1466] Reorder Routes to Make All Paths Lead to the City Zero
 */

import java.util.ArrayDeque;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Queue;
import java.util.Set;

// @lc code=start

class Solution {
    public int minReorder(int n, int[][] connections) {
        Map<Integer, Set<Integer>> ins = new HashMap<>(), outs = new HashMap<>();
        for (int[] conn : connections) {
            int a = conn[0], b = conn[1];
            ins.computeIfAbsent(b, i -> new HashSet<>()).add(a);
            outs.computeIfAbsent(a, i -> new HashSet<>()).add(b);
        }
        int ret = 0;
        Set<Integer> seen = new HashSet<>(n);
        Queue<Integer> queue = new ArrayDeque<>();
        queue.offer(0);
        seen.add(0);
        while (!queue.isEmpty()) {
            int curr = queue.poll();
            Set<Integer> in = ins.getOrDefault(curr, Collections.emptySet());
            for (int i : in) {
                if (seen.add(i)) {
                    queue.offer(i);
                }
            }
            Set<Integer> out = outs.getOrDefault(curr, Collections.emptySet());
            for (int o : out) {
                if (seen.add(o)) {
                    ++ret;
                    queue.offer(o);
                }
            }
        }
        return ret;
    }
}
// @lc code=end

