/*
 * @lc app=leetcode id=1817 lang=java
 *
 * [1817] Finding the Users Active Minutes
 */

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

// @lc code=start
class Solution {
    public int[] findingUsersActiveMinutes(int[][] logs, int k) {
        Map<Integer, Set<Integer>> count = new HashMap<>();
        for (int[] log : logs) {
            int u = log[0], m = log[1];
            count.computeIfAbsent(u, i -> new HashSet<>()).add(m);
        }
        int[] ret = new int[k];
        for (var s : count.values()) {
            ++ret[s.size() - 1];
        }
        return ret;
    }
}
// @lc code=end

