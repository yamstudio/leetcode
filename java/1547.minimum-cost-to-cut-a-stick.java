/*
 * @lc app=leetcode id=1547 lang=java
 *
 * [1547] Minimum Cost to Cut a Stick
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int minCost(int n, int[] cuts) {
        int k = cuts.length;
        int[] allCuts = new int[k + 2];
        for (int i = 0; i < k; ++i) {
            allCuts[i + 1] = cuts[i];
        }
        k += 2;
        allCuts[k - 1] = n;
        Arrays.sort(allCuts);
        int[][] totalCost = new int[k][k];
        for (int len = 2; len < k; ++len) {
            for (int left = 0; left + len < k; ++left) {
                int cost = allCuts[left + len] - allCuts[left];
                totalCost[left][left + len] = 1000000000;
                for (int cut = left + 1; cut < left + len; ++cut) {
                    totalCost[left][left + len] = Math.min(cost + totalCost[left][cut] + totalCost[cut][left + len], totalCost[left][left + len]);
                }
            }
        }
        return totalCost[0][k - 1];
    }
}
// @lc code=end

