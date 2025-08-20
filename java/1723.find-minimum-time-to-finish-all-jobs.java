/*
 * @lc app=leetcode id=1723 lang=java
 *
 * [1723] Find Minimum Time to Finish All Jobs
 */

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

// @lc code=start
class Solution {
    public int minimumTimeRequired(int[] jobs, int k) {
        int n = jobs.length;
        List<Set<Integer>> sets = new ArrayList<>();
        for (int i = 0; i < n; ++i) {
            sets.add(new HashSet<>(k));
        }
        Arrays.sort(jobs);
        return minimumTimeRequired(jobs, new int[k], n - 1, Integer.MAX_VALUE, sets);
    }

    private static int minimumTimeRequired(int[] jobs, int[] workers, int i, int currMin, List<Set<Integer>> sets) {
        if (i < 0) {
            int ret = Integer.MIN_VALUE;
            for (int w : workers) {
                ret = Math.max(w, ret);
            }
            return Math.min(ret, currMin);
        }
        int k = workers.length, ret = currMin;
        Set<Integer> visited = sets.get(i);
        visited.clear();
        for (int j = 0; j < k; ++j) {
            int w = workers[j];
            if (visited.contains(w)) {
                continue;
            }
            if (w + jobs[i] >= ret) {
                continue;
            }
            visited.add(w);
            workers[j] += jobs[i];
            ret = Math.min(ret, minimumTimeRequired(jobs, workers, i - 1, ret, sets));
            workers[j] -= jobs[i];
        }
        return ret;
    }
}
// @lc code=end

