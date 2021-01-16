/*
 * @lc app=leetcode id=785 lang=java
 *
 * [785] Is Graph Bipartite?
 */

// @lc code=start
class Solution {

    private static boolean isBipartite(int[][] graph, int[] colors, int color, int curr) {
        if (colors[curr] != 0) {
            return color == colors[curr];
        }
        colors[curr] = color;
        for (int next : graph[curr]) {
            if (!isBipartite(graph, colors, -color, next)) {
                return false;
            }
        }
        return true;
    }

    public boolean isBipartite(int[][] graph) {
        int n = graph.length;
        int[] colors = new int[n];
        for (int i = 0; i < n; ++i) {
            if (colors[i] == 0 && !isBipartite(graph, colors, 1, i)) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

