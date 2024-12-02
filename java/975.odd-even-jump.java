/*
 * @lc app=leetcode id=975 lang=java
 *
 * [975] Odd Even Jump
 */

import java.util.TreeMap;

// @lc code=start

class Solution {
    public int oddEvenJumps(int[] arr) {
        TreeMap<Integer, Integer> valToIndex = new TreeMap<>();
        int n = arr.length, ret = 1;
        boolean[][] dp = new boolean[n][2];
        dp[n - 1][0] = true;
        dp[n - 1][1] = true;
        valToIndex.put(arr[n - 1], n - 1);
        for (int i = n - 2; i >= 0; --i) {
            int val = arr[i];
            Integer ceiling = valToIndex.ceilingKey(val);
            if (ceiling != null && dp[valToIndex.get(ceiling)][1]) {
                dp[i][0] = true;
                ++ret;
            }
            Integer floor = valToIndex.floorKey(val);
            if (floor != null) {
                dp[i][1] = dp[valToIndex.get(floor)][0];
            }
            valToIndex.put(val, i);
        }
        return ret;
    }
}
// @lc code=end

