/*
 * @lc app=leetcode id=1557 lang=java
 *
 * [1557] Minimum Number of Vertices to Reach All Nodes
 */

import java.util.List;
import java.util.stream.IntStream;

// @lc code=start
class Solution {
    public List<Integer> findSmallestSetOfVertices(int n, List<List<Integer>> edges) {
        var exclude = edges.stream().map(edge -> edge.get(1)).collect(java.util.stream.Collectors.toUnmodifiableSet());
        return IntStream.range(0, n).boxed().filter(x -> !exclude.contains(x)).toList();
    }
}
// @lc code=end

