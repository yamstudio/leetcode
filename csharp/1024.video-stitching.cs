/*
 * @lc app=leetcode id=1024 lang=csharp
 *
 * [1024] Video Stitching
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int VideoStitching(int[][] clips, int T) {
        int n = clips.Length, prev = 0, curr = 0, i = 0, ret = 0;
        clips = clips.OrderBy(p => p[0]).ToArray();
        while (curr < T) {
            while (i < n && clips[i][0] <= prev) {
                curr = Math.Max(curr, clips[i++][1]);
            }
            if (prev == curr) {
                return -1;
            }
            prev = curr;
            ++ret;
        }
        return ret;
    }
}
// @lc code=end

