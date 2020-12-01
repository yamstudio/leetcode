/*
 * @lc app=leetcode id=1512 lang=csharp
 *
 * [1512] Number of Good Pairs
 */

// @lc code=start
public class Solution {
    public int NumIdenticalPairs(int[] nums) {
        int ret = 0;
        var count = new int[101];
        foreach (var x in nums) {
            ret += count[x]++;
        }
        return ret;
    }
}
// @lc code=end

