/*
 * @lc app=leetcode id=1782 lang=java
 *
 * [1782] Count Pairs Of Nodes
 */

import java.util.Arrays;
import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int[] countPairs(int n, int[][] edges, int[] queries) {
        int[] count = new int[n];
        Map<Integer, Map<Integer, Integer>> dup = new HashMap<>();
        for (int[] edge : edges) {
            int a = edge[0] - 1, b = edge[1] - 1;
            if (a > b) {
                int t = a;
                a = b;
                b = t;
            }
            ++count[a];
            ++count[b];
            var d = dup.computeIfAbsent(a, ignored -> new HashMap<>());
            d.put(b, d.getOrDefault(b, 0) + 1);
        }
        int[] sorted = Arrays.copyOf(count, n);
        Arrays.sort(sorted);
        int len = queries.length;
        int[] ret = new int[len];
        for (int i = 0; i < len; ++i) {
            int c = 0, q = queries[i];
            for (int l = 0, r = n - 1; l < r;) {
                if (sorted[l] + sorted[r] > q) {
                    c += r - l;
                    --r;
                } else {
                    ++l;
                }
            }
            for (int a = 0; a < n; ++a) {
                var d = dup.get(a);
                if (d == null) {
                    continue;
                }
                for (var ent : d.entrySet()) {
                    int b = ent.getKey();
                    int sum = count[a] + count[b];
                    if (sum > q && sum - ent.getValue() <= q) {
                        --c;
                    }
                }
            }
            ret[i] = c;
        }
        return ret;
    }
}
// @lc code=end

