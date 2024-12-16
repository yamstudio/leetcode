/*
 * @lc app=leetcode id=1029 lang=java
 *
 * [1029] Two City Scheduling
 */

import java.util.Arrays;
import java.util.List;

// @lc code=start

import static java.util.Comparator.comparing;

class Solution {
    public int twoCitySchedCost(int[][] costs) {
        List<int[]> sorted = Arrays.stream(costs)
            .sorted(comparing(cost -> cost[0] - cost[1]))
            .toList();
        int n = costs.length / 2, ret = 0;
        for (int i = 0; i < n; ++i) {
            ret += sorted.get(i)[0] + sorted.get(i + n)[1];
        }
        return ret;
    }
}
// @lc code=end

