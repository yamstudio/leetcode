/*
 * @lc app=leetcode id=1481 lang=java
 *
 * [1481] Least Number of Unique Integers after K Removals
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

// @lc code=start

class Solution {
    public int findLeastNumOfUniqueInts(int[] arr, int k) {
        Map<Integer, Integer> count = new HashMap<>();
        for (int x : arr) {
            count.put(x, count.getOrDefault(x, 0) + 1);
        }
        List<Integer> vals = new ArrayList<>(count.values());
        Collections.sort(vals);
        int i, n = vals.size();
        for (i = 0; i < n && k >= vals.get(i); ++i) {
            k -= vals.get(i);
        }
        return n - i;
    }
}
// @lc code=end

