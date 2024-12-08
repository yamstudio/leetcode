/*
 * @lc app=leetcode id=996 lang=java
 *
 * [996] Number of Squareful Arrays
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int numSquarefulPerms(int[] nums) {
        int n = nums.length, target = (1 << n) - 1;
        boolean[][] perfect = new boolean[n][n];
        int[] sorted = Arrays.stream(nums).sorted().toArray();
        for (int i = 0; i < n; ++i) {
            for (int j = i + 1; j < n; ++j) {
                int sum = sorted[i] + sorted[j], sqrt = (int)Math.sqrt(sum);
                if (sum == sqrt * sqrt) {
                    perfect[i][j] = true;
                    perfect[j][i] = true;
                }
            }
        }
        int[][] count = new int[target + 1][n];
        for (int i = 0; i < n; ++i) {
            if (i == 0 || sorted[i] != sorted[i - 1]) {
                count[1 << i][i] = 1;
            }
        }
        for (int used = 1; used <= target; ++used) {
            for (int i = 0; i < n; ++i) {
                if (count[used][i] == 0) {
                    continue;
                }
                for (int j = 0; j < n; ++j) {
                    if ((used & (1 << j)) != 0 || !perfect[i][j] || (j > 0 && sorted[j] == sorted[j - 1] && (used & (1 << (j - 1))) == 0)) {
                        continue;
                    }
                    count[used | (1 << j)][j] += count[used][i];
                }
            }
        }
        int ret = 0;
        for (int i = 0; i < n; ++i) {
            ret += count[target][i];
        }
        return ret;
    }
}
// @lc code=end

