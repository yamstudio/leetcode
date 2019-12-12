/*
 * @lc app=leetcode id=746 lang=csharp
 *
 * [746] Min Cost Climbing Stairs
 */

// @lc code=start
public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        int p = 0, pp = 0, n = cost.Length;
        foreach (var c in cost) {
            int curr = Math.Min(p, pp) + c;
            pp = p;
            p = curr;
        }
        return Math.Min(p, pp);
    }
}
// @lc code=end

