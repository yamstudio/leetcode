/*
 * @lc app=leetcode id=785 lang=csharp
 *
 * [785] Is Graph Bipartite?
 */

// @lc code=start
public class Solution {

    private static bool IsBipartiteRecurse(int[][] graph, int[] arr, int curr, int i) {
        if (arr[i] != 0) {
            return curr == arr[i];
        }
        arr[i] = curr;
        foreach (var j in graph[i]) {
            if (!IsBipartiteRecurse(graph, arr, -curr, j)) {
                return false;
            }
        }
        return true;
    }

    public bool IsBipartite(int[][] graph) {
        int n = graph.Length;
        int[] arr = new int[n];
        for (int i = 0; i < n; ++i) {
            if (arr[i] == 0 && !IsBipartiteRecurse(graph, arr, 1, i)) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

