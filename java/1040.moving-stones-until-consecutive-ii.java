/*
 * @lc app=leetcode id=1040 lang=java
 *
 * [1040] Moving Stones Until Consecutive II
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int[] numMovesStonesII(int[] stones) {
        int n = stones.length, l = 0, min = n;
        Arrays.sort(stones);
        for (int r = 0; r < n; ++r) {
            while (stones[r] - stones[l] >= n) {
                ++l;
            }
            int moves = n - (r - l + 1);
            if (moves == 1 && stones[r] - stones[l] == n - 2) {
                min = Math.min(2, min);
            } else {
                min = Math.min(moves, min);
            }
        }
        return new int[] {
            min,
            Math.max(stones[n - 1] - stones[1] - (n - 2), stones[n - 2] - stones[0] - (n - 2))
        };
    }
}
// @lc code=end

