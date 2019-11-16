/*
 * @lc app=leetcode id=674 lang=csharp
 *
 * [674] Longest Continuous Increasing Subsequence
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int FindLengthOfLCIS(int[] nums) {
        return nums.Aggregate((Count: 0, Prev: int.MaxValue, Ret: 0), (acc, curr) => curr > acc.Prev ? (acc.Count + 1, curr, Math.Max(acc.Count + 1, acc.Ret)) : (1, curr, Math.Max(acc.Ret, 1)), acc => acc.Ret);
    }
}
// @lc code=end

