/*
 * @lc app=leetcode id=797 lang=java
 *
 * [797] All Paths From Source to Target
 */

// @lc code=start
class Solution {

    private static void addPaths(int[][] graph, List<List<Integer>> ret, List<Integer> path) {
        int curr = path.get(path.size() - 1);
        if (curr == graph.length - 1) {
            ret.add(new ArrayList<Integer>(path));
            return;
        }
        for (int next : graph[curr]) {
            path.add(next);
            addPaths(graph, ret, path);
            path.remove(path.size() - 1);
        }
    }

    public List<List<Integer>> allPathsSourceTarget(int[][] graph) {
        List<List<Integer>> ret = new ArrayList<List<Integer>>();
        List<Integer> path = new ArrayList<Integer>();
        path.add(0);
        addPaths(graph, ret, path);
        return ret;
    }
}
// @lc code=end

