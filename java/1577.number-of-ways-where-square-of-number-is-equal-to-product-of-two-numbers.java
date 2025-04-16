/*
 * @lc app=leetcode id=1577 lang=java
 *
 * [1577] Number of Ways Where Square of Number Is Equal to Product of Two Numbers
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int numTriplets(int[] nums1, int[] nums2) {
        Map<Integer, Integer> count1 = new HashMap<>(), count2 = new HashMap<>();
        for (int x : nums1) {
            count1.put(x, count1.getOrDefault(x, 0) + 1);
        }
        for (int x : nums2) {
            count2.put(x, count2.getOrDefault(x, 0) + 1);
        }
        return numTriplets(count1, count2) + numTriplets(count2, count1);
    }

    private static int numTriplets(Map<Integer, Integer> arr, Map<Integer, Integer> other) {
        int ret = 0;
        for (var numToCount : arr.entrySet()) {
            int num = numToCount.getKey(), count = numToCount.getValue();
            long target = (long)num * (long)num;
            for (int l = 1; l <= num; ++l) {
                if (target % l != 0) {
                    continue;
                }
                Integer c1 = other.get(l), c2 = other.get((int)(target / (long)l));
                if (c1 == null || c2 == null) {
                    continue;
                }
                if (l == num) {
                    ret += count * c1 * (c1 - 1) / 2;
                } else {
                    ret += count * c1 * c2;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

