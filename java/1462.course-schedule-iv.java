/*
 * @lc app=leetcode id=1462 lang=java
 *
 * [1462] Course Schedule IV
 */

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

// @lc code=start
class Solution {
    public List<Boolean> checkIfPrerequisite(int numCourses, int[][] prerequisites, int[][] queries) {
        Boolean[][] memo = new Boolean[numCourses][numCourses];
        for (int i = 0; i < numCourses; ++i) {
            memo[i][i] = false;
        }
        for (int[] pair : prerequisites) {
            int a = pair[0], b = pair[1];
            memo[a][b] = false;
            memo[b][a] = true;
        }
        List<Boolean> ret = new ArrayList<>(queries.length);
        for (int[] query : queries) {
            ret.add(isPrereq(query[0], query[1], memo));
        }
        return ret;
    }

    private static boolean isPrereq(int a, int b, Boolean[][] memo) {
        Boolean existing = memo[b][a];
        if (existing != null) {
            return existing;
        }
        boolean ret = false;
        int n = memo.length;
        for (int i = 0; i < n && !ret; ++i) {
            ret |= (Objects.equals(memo[b][i], Boolean.TRUE)) && isPrereq(a, i, memo);
        }
        memo[b][a] = ret;
        return ret;
    }
}
// @lc code=end

