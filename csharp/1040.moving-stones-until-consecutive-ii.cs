/*
 * @lc app=leetcode id=1040 lang=csharp
 *
 * [1040] Moving Stones Until Consecutive II
 */

using System;

// @lc code=start
public class Solution {
    public int[] NumMovesStonesII(int[] stones) {
        int n = stones.Length, min = n, l = 0;
        Array.Sort(stones);
        for (int r = 0; r < n; ++r) {
            while (stones[r] - stones[l] >= n) {
                ++l;
            }
            int moves = n - (r - l + 1);
            if (moves == 1 && stones[r] - stones[l] == n - 2) {
                ++moves;
            }
            min = Math.Min(moves, min);
        }
        return new int[] {
            min,
            Math.Max(stones[n - 1] - stones[1], stones[n - 2] - stones[0]) - n + 2
        };
    }
}
// @lc code=end

