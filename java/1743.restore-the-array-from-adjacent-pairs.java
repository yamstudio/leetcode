/*
 * @lc app=leetcode id=1743 lang=java
 *
 * [1743] Restore the Array From Adjacent Pairs
 */

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.HashSet;

// @lc code=start

class Solution {
    public int[] restoreArray(int[][] adjacentPairs) {
        int n = adjacentPairs.length + 1;
        List<Integer> ret = new ArrayList<>(n);
        Map<Integer, Set<Integer>> nbs = new HashMap<>(n);
        for (int[] pair : adjacentPairs) {
            int x = pair[0], y = pair[1];
            nbs.computeIfAbsent(x, i -> new HashSet<>(2)).add(y);
            nbs.computeIfAbsent(y, i -> new HashSet<>(2)).add(x);
        }
        int curr = 0;
        for (var entry : nbs.entrySet()) {
            if (entry.getValue().size() == 1) {
                curr = entry.getKey();
                break;
            }
        }
        while (true) {
            ret.add(curr);
            Set<Integer> neighbors = nbs.get(curr);
            if (neighbors.size() == 0) {
                break;
            }
            int next = neighbors.stream().findFirst().orElseThrow();
            nbs.get(next).remove(curr);
            curr = next;
        }
        return ret.stream().mapToInt(i -> i).toArray();
    }
}
// @lc code=end

