/*
 * @lc app=leetcode id=1449 lang=csharp
 *
 * [1449] Form Largest Integer With Digits That Add up to Target
 */

using System;
using System.Text;

// @lc code=start
public class Solution {
    public string LargestNumber(int[] cost, int target) {
        var dp = new int[target + 1];
        for (int i = 1; i <= target; ++i) {
            int b = -10000;
            for (int d = 0; d < 9; ++d) {
                if (i >= cost[d]) {
                    b = Math.Max(b, dp[i - cost[d]] + 1);
                }
            }
            dp[i] = b;
        }
        if (dp[target] < 0) {
            return "0";
        }
        var ret = new StringBuilder(dp[target]);
        for (int d = 8; d >= 0; --d) {
            while (target >= cost[d] && 1 + dp[target - cost[d]] == dp[target]) {
                ret.Append(d + 1);
                target -= cost[d];
            }
        }
        return ret.ToString();
    }
}
// @lc code=end

