/*
 * @lc app=leetcode id=1037 lang=csharp
 *
 * [1037] Valid Boomerang
 */

// @lc code=start
public class Solution {
    public bool IsBoomerang(int[][] points) {
        return (points[0][0] - points[2][0]) * (points[0][1] - points[1][1]) != (points[0][1] - points[2][1]) * (points[0][0] - points[1][0]);
    }
}
// @lc code=end

