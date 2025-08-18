/*
 * @lc app=leetcode id=1710 lang=java
 *
 * [1710] Maximum Units on a Truck
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int maximumUnits(int[][] boxTypes, int truckSize) {
        int ret = 0, k = boxTypes.length;
        Arrays.sort(boxTypes, java.util.Comparator.comparing(b -> -b[1]));
        for (int i = 0; i < k && truckSize > 0; ++i) {
            int[] t = boxTypes[i];
            int b = Math.min(truckSize, t[0]);
            ret += b * t[1];
            truckSize -= b;
        }
        return ret;
    }
}
// @lc code=end

