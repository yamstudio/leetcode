/*
 * @lc app=leetcode id=1049 lang=csharp
 *
 * [1049] Last Stone Weight II
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int LastStoneWeightII(int[] stones) {
        int sum = stones.Sum(), h = sum / 2;
        bool[] dp = new bool[h + 1];
        dp[0] = true;
        foreach (int stone in stones) {
            for (int s = h; s >= stone; --s) {
                dp[s] = dp[s] || dp[s - stone];
            }
        }
        for (int s = h; s >= 0; --s) {
            if (dp[s]) {
                return sum - s * 2;
            }
        }
        return -1;
    }
}
// @lc code=end

