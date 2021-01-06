/*
 * @lc app=leetcode id=1672 lang=csharp
 *
 * [1672] Richest Customer Wealth
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int MaximumWealth(int[][] accounts) {
        return accounts.Max(t => t.Sum());
    }
}
// @lc code=end

