/*
 * @lc app=leetcode id=1144 lang=csharp
 *
 * [1144] Decrease Elements To Make Array Zigzag
 */

using System;

// @lc code=start
public class Solution {
    public int MovesToMakeZigzag(int[] nums) {
        int n = nums.Length;
        (int Moves, int Value)[,] dp = new (int Moves, int Value)[2, n];
        dp[0, 0] = (Moves: 0, Value: nums[0]);
        dp[1, 0] = (Moves: 0, Value: nums[0]);
        for (int i = 1; i < n; ++i) {
            int curr = nums[i];
            var pd = dp[0, i - 1];
            var pu = dp[1, i - 1];
            if (curr > pd.Value) {
                dp[1, i] = (Moves: pd.Moves, Value: curr);
            } else {
                dp[1, i] = (Moves: pd.Moves + pd.Value - curr + 1, Value: curr);
            }
            if (curr < pu.Value) {
                dp[0, i] = (Moves: pu.Moves, Value: curr);
            } else {
                dp[0, i] = (Moves: pu.Moves + 1 + curr - pu.Value, Value: pu.Value - 1);
            }
        }
        return Math.Min(dp[0, n - 1].Moves, dp[1, n - 1].Moves);
    }
}
// @lc code=end

