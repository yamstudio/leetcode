/*
 * @lc app=leetcode id=1595 lang=java
 *
 * [1595] Minimum Cost to Connect Two Groups of Points
 */

import java.util.List;

// @lc code=start
class Solution {
    public int connectTwoGroups(List<List<Integer>> cost) {
        int m = cost.size(), n = cost.get(0).size();
        int[] colMin = new int[n];
        for (int j = 0; j < n; ++j) {
            colMin[j] = cost.get(0).get(j);
        }
        for (int i = 1; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                colMin[j] = Math.min(colMin[j], cost.get(i).get(j));
            }
        }
        return connectTwoGroups(cost, colMin, 0, 0, new Integer[m + 1][1 << n]);
    }

    private int connectTwoGroups(List<List<Integer>> cost, int[] colMin, int i, int colState, Integer[][] memo) {
        int m = cost.size(), n = cost.get(0).size();
        Integer v = memo[i][colState];
        if (v != null) {
            return v;
        }
        if (i == m) {
            int c = 0;
            for (int j = 0; j < n; ++j) {
                if (((1 << j) & colState) != 0) {
                    continue;
                }
                c += colMin[j];
            }
            memo[i][colState] = c;
            return c;
        }
        int ret = Integer.MAX_VALUE;
        for (int j = 0; j < n; ++j) {
            ret = Math.min(ret, cost.get(i).get(j) + connectTwoGroups(cost, colMin, i + 1, colState | (1 << j), memo));
        }
        memo[i][colState] = ret;
        return ret;
    }
}
// @lc code=end

