/*
 * @lc app=leetcode id=1460 lang=java
 *
 * [1460] Make Two Arrays Equal by Reversing Subarrays
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public boolean canBeEqual(int[] target, int[] arr) {
        Map<Integer, Integer> diff = new HashMap<>();
        int n = target.length;
        for (int i = 0; i < n; ++i) {
            int v1 = target[i], v2 = arr[i];
            diff.put(v1, diff.getOrDefault(v1, 0) + 1);
            diff.put(v2, diff.getOrDefault(v2, 0) - 1);
        }
        return !diff.values().stream().anyMatch(c -> c != 0);
    }
}
// @lc code=end

