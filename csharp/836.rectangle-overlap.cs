/*
 * @lc app=leetcode id=836 lang=csharp
 *
 * [836] Rectangle Overlap
 */

// @lc code=start
public class Solution {
    public bool IsRectangleOverlap(int[] rec1, int[] rec2) {
        return rec1[0] < rec2[2] && rec2[0] < rec1[2] && rec1[1] < rec2[3] && rec2[1] < rec1[3];
    }
}
// @lc code=end

