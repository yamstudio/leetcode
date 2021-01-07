/*
 * @lc app=leetcode id=1674 lang=csharp
 *
 * [1674] Minimum Moves to Make Array Complementary
 */

using System;

// @lc code=start
public class Solution {
    public int MinMoves(int[] nums, int limit) {
        int max = limit * 2, n = nums.Length, ret = n, acc = n;
        int[] changes = new int[max + 2];
        for (int i = 0; i * 2 < n; ++i) {
            int a = nums[i], b = nums[n - 1 - i];
            changes[Math.Min(a, b) + 1]--;
            changes[a + b]--;
            changes[a + b + 1]++;
            changes[Math.Max(a, b) + limit + 1]++;
        }
        for (int i = 2; i <= max; ++i) {
            acc += changes[i];
            ret = Math.Min(ret, acc);
        }
        return ret;
    }
}
// @lc code=end

