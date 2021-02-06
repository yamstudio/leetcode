/*
 * @lc app=leetcode id=847 lang=java
 *
 * [847] Shortest Path Visiting All Nodes
 */

// @lc code=start
class Solution {
    public int shortestPathLength(int[][] graph) {
        int ret = 0, n = graph.length, target = (1 << n) - 1;
        Set<String> visited = new HashSet<String>();
        Queue<int[]> queue = new LinkedList<int[]>();
        for (int i = 0; i < n; ++i) {
            visited.add(String.format("%d,%d", 1 << i, i));
            queue.offer(new int[] { 1 << i, i });
        }
        while (queue.size() > 0) {
            for (int i = queue.size(); i > 0; --i) {
                int[] curr = queue.poll();
                if (curr[0] == target) {
                    return ret;
                }
                for (int next : graph[curr[1]]) {
                    if (visited.add(String.format("%d,%d", curr[0] | (1 << next), next))) {
                        queue.offer(new int[] { curr[0] | (1 << next), next });
                    }
                }
            }
            ++ret;
        }
        return -1;
    }
}
// @lc code=end

