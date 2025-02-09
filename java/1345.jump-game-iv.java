/*
 * @lc app=leetcode id=1345 lang=java
 *
 * [1345] Jump Game IV
 */

import java.util.ArrayDeque;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Queue;
import java.util.Set;

// @lc code=start
class Solution {
    public int minJumps(int[] arr) {
        int n = arr.length;
        Map<Integer, Set<Integer>> valToIndices = new HashMap<>();
        for (int i = 0; i < n; ++i) {
            valToIndices.computeIfAbsent(arr[i], ignored -> new HashSet<>()).add(i);
        }
        Set<Integer> visited = new HashSet<>();
        Queue<Integer> queue = new ArrayDeque<>();
        int ret = 0;
        queue.offer(0);
        visited.add(0);
        while (!queue.isEmpty()) {
            for (int k = queue.size(); k > 0; --k) {
                int i = queue.poll();
                if (i == n - 1) {
                    return ret;
                }
                for (int j : valToIndices.get(arr[i])) {
                    if (visited.add(j)) {
                        queue.offer(j);
                    }
                }
                valToIndices.get(arr[i]).clear();
                if (i > 0 && visited.add(i - 1)) {
                    queue.offer(i - 1);
                }
                if (visited.add(i + 1)) {
                    queue.offer(i + 1);
                }
            }
            ++ret;
        }
        return -1;
    }
}
// @lc code=end

