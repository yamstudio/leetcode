/*
 * @lc app=leetcode id=1203 lang=java
 *
 * [1203] Sort Items by Groups Respecting Dependencies
 */

import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

// @lc code=start
class Solution {
    public int[] sortItems(int n, int m, int[] group, List<List<Integer>> beforeItems) {
        int k = n + 2 * m;
        Map<Integer, Set<Integer>> deps = new HashMap<>(k);
        for (int i = 0; i < k; ++i) {
            deps.put(i, new HashSet<>());
        }
        for (int i = 0; i < n; ++i) {
            int g = group[i];
            if (g != -1) {
                int groupStart = n + g, groupEnd = n + m + g;
                deps.get(i).add(groupEnd);
                deps.get(groupStart).add(i);
            }
            for (int b : beforeItems.get(i)) {
                int iStart = group[i] == -1 ? i : n + group[i];
                int bEnd = group[b] == -1 ? b : n + m + group[b];
                if (iStart >= n && iStart + m == bEnd) {
                    deps.get(b).add(i);
                } else {
                    deps.get(bEnd).add(iStart);
                }
            }
        }
        int[] state = new int[k];
        List<Integer> sorted = new ArrayList<>(k);
        for (int i = k - 1; i >= 0; --i) {
            if (!add(deps, sorted, i, state)) {
                return new int[0];
            }
        }
        int[] ret = new int[n];
        for (int i = k - 1, j = 0; i >= 0 && j < n; --i) {
            int curr = sorted.get(i);
            if (curr >= n) {
                continue;
            }
            ret[j++] = curr;
        }
        return ret;
    }

    private boolean add(Map<Integer, Set<Integer>> deps, List<Integer> sorted, int curr, int[] state) {
        if (state[curr] == 1) {
            return false;
        }
        if (state[curr] == 2) {
            return true;
        }
        state[curr] = 1;
        for (int dep : deps.get(curr)) {
            if (!add(deps, sorted, dep, state)) {
                return false;
            }
        }
        sorted.add(curr);
        state[curr] = 2;
        return true;
    }
}
// @lc code=end

