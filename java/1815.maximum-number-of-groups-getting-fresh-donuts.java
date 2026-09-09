/*
 * @lc app=leetcode id=1815 lang=java
 *
 * [1815] Maximum Number of Groups Getting Fresh Donuts
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int maxHappyGroups(int batchSize, int[] groups) {
        int ret = 0;
        int[] qs = new int[batchSize];
        for (int g : groups) {
            int q = g % batchSize;
            if (q == 0) {
                ++ret;
            } else if (qs[batchSize - q] == 0) {
                ++qs[q];
            } else {
                --qs[batchSize - q];
                ++ret;
            }
        }
        return ret + maxHappyGroups(qs, 0, new HashMap<>());
    }

    private static int maxHappyGroups(int[] qs, int q, Map<String, Integer> memo) {
        String key = key(qs);
        Integer v = memo.get(key);
        if (v != null) {
            return v;
        }
        int ret = 0, batchSize = qs.length;
        for (int next = 1; next < batchSize; ++next) {
            int m = qs[next];
            if (m == 0) {
                continue;
            }
            qs[next] = m - 1;
            ret = Math.max(ret, maxHappyGroups(qs, (batchSize + q - next) % batchSize, memo) + (q == 0 ? 1 : 0));
            qs[next] = m;
        }
        memo.put(key, ret);
        return ret;
    }

    private static String key(int[] qs) {
        StringBuilder sb = new StringBuilder();
        for (int q : qs) {
            sb.append(q);
            sb.append(',');
        }
        return sb.toString();
    }
}
// @lc code=end

