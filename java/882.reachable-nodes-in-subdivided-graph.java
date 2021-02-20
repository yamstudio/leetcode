/*
 * @lc app=leetcode id=882 lang=java
 *
 * [882] Reachable Nodes In Subdivided Graph
 */

// @lc code=start
class Solution {
    public int reachableNodes(int[][] edges, int maxMoves, int n) {
        int ret = 0;
        int[][] map = new int[n][n];
        boolean[] visited = new boolean[n];
        Queue<int[]> queue = new PriorityQueue<int[]>((a, b) -> Integer.compare(b[1], a[1]));
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                map[i][j] = -1;
            }
        }
        for (int[] edge : edges) {
            int a = edge[0], b = edge[1], v = edge[2];
            map[a][b] = v;
            map[b][a] = v;
        }
        queue.offer(new int[] { 0, maxMoves });
        while (queue.size() > 0) {
            int[] curr = queue.poll();
            int i = curr[0], m = curr[1];
            if (visited[i]) {
                continue;
            }
            visited[i] = true;
            ++ret;
            for (int j = 0; j < n; ++j) {
                int dist = map[i][j];
                if (dist < 0) {
                    continue;
                }
                if (dist < m) {
                    queue.offer(new int[] { j, m - dist - 1 });
                } else {
                    dist = m;
                }
                ret += dist;
                map[j][i] -= dist;
            }
        }
        return ret;
    }
}
// @lc code=end

