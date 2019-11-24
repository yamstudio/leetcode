/*
 * @lc app=leetcode id=699 lang=csharp
 *
 * [699] Falling Squares
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public IList<int> FallingSquares(int[][] positions) {
        int n = positions.Length;
        int[] heights = new int[n];
        for (int i = 0; i < n; ++i) {
            int l = positions[i][0], len = positions[i][1], r = l + len;
            heights[i] += len;
            for (int j = i + 1; j < n; ++j) {
                int nl = positions[j][0];
                if (nl < r && nl + positions[j][1] > l) {
                    heights[j] = Math.Max(heights[i], heights[j]);
                }
            }
        }
        for (int i = 1; i < n; ++i) {
            heights[i] = Math.Max(heights[i], heights[i - 1]);
        }
        return heights;
    }
}
// @lc code=end

