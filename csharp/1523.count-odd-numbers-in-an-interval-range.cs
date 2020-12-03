/*
 * @lc app=leetcode id=1523 lang=csharp
 *
 * [1523] Count Odd Numbers in an Interval Range
 */

// @lc code=start
public class Solution {
    public int CountOdds(int low, int high) {
        return (high + 1) / 2 - low / 2;
    }
}
// @lc code=end

