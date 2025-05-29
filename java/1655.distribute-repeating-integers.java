/*
 * @lc app=leetcode id=1655 lang=java
 *
 * [1655] Distribute Repeating Integers
 */

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

// @lc code=start

class Solution {
    public boolean canDistribute(int[] nums, int[] quantity) {
        Map<Integer, Integer> countMap = new HashMap<>();
        for (int i : nums) {
            countMap.put(i, countMap.getOrDefault(i, 0) + 1);
        }
        List<Integer> counts = new ArrayList<>(countMap.values());
        Collections.sort(counts, java.util.Comparator.reverseOrder());
        Arrays.sort(quantity);
        return canDistribute(counts, quantity, quantity.length - 1);
    }

    private static boolean canDistribute(List<Integer> counts, int[] quantity, int i) {
        if (i < 0) {
            return true;
        }
        int q = quantity[i], k = counts.size();
        for (int j = 0; j < k; ++j) {
            int c = counts.get(j);
            if (c < q) {
                continue;
            }
            counts.set(j, c - q);
            if (canDistribute(counts, quantity, i - 1)) {
                return true;
            }
            counts.set(j, c);
        }
        return false;
    }
}
// @lc code=end

