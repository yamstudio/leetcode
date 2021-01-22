/*
 * @lc app=leetcode id=802 lang=java
 *
 * [802] Find Eventual Safe States
 */

// @lc code=start
class Solution {
    
    private static boolean visit(int[][] graph, int curr, int[] states) {
        if (states[curr] != 0) {
            return states[curr] == 2;
        }
        states[curr] = 1;
        for (int next : graph[curr]) {
            if (!visit(graph, next, states)) {
                return false;
            }
        }
        states[curr] = 2;
        return true;
    }
    
    public List<Integer> eventualSafeNodes(int[][] graph) {
        int n = graph.length;
        List<Integer> ret = new ArrayList<Integer>();
        int[] states = new int[n];
        for (int i = 0; i < n; ++i) {
            if (visit(graph, i, states)) {
                ret.add(i);
            }
        }
        return ret;
    }
}
// @lc code=end

