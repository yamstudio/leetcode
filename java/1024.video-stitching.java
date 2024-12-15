/*
 * @lc app=leetcode id=1024 lang=java
 *
 * [1024] Video Stitching
 */

import java.util.Arrays;
import java.util.List;

// @lc code=start

import static java.util.Comparator.comparing;

class Solution {
    public int videoStitching(int[][] clips, int time) {
        int n = clips.length, ret = 0, i = 0, prevEnd = 0, curr = 0;
        List<int[]> sorted = Arrays.stream(clips).sorted(comparing(clip -> clip[0])).toList();
        while (curr < time) {
            while (i < n && sorted.get(i)[0] <= prevEnd) {
                curr = Math.max(curr, sorted.get(i)[1]);
                ++i;
            }
            if (prevEnd == curr) {
                return -1;
            }
            ++ret;
            prevEnd = curr;
        }
        return ret;
    }
}
// @lc code=end

