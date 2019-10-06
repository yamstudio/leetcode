/*
 * @lc app=leetcode id=497 lang=csharp
 *
 * [497] Random Point in Non-overlapping Rectangles
 */

using System;

// @lc code=start
public class Solution {

    private (int, int[])[] Map;
    private Random Random;
    private int Total;

    public Solution(int[][] rects) {
        int n = rects.Length;
        Map = new (int, int[])[n];
        Total = 0;
        Random = new Random();
        for (int i = 0; i < n; ++i) {
            var rect = rects[i];
            Total += (rect[2] - rect[0] + 1) * (rect[3] - rect[1] + 1);
            Map[i] = (Total, rect);
        }
    }
    
    public int[] Pick() {
        int rand = Random.Next(1, Total + 1), left = 0, right = Map.Length - 1;
        while (left < right) {
            int mid = (left + right) / 2;
            if (Map[mid].Item1 < rand) {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        int[] rect = Map[left].Item2;
        return new int[] {
            Random.Next(rect[0], rect[2] + 1),
            Random.Next(rect[1], rect[3] + 1),
        };
    }
}

/**
 * Your Solution object will be instantiated and called as such:
 * Solution obj = new Solution(rects);
 * int[] param_1 = obj.Pick();
 */
// @lc code=end

