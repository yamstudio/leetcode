/*
 * @lc app=leetcode id=986 lang=java
 *
 * [986] Interval List Intersections
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start

class Solution {
    public int[][] intervalIntersection(int[][] firstList, int[][] secondList) {
        int i = 0, j = 0, m = firstList.length, n = secondList.length;
        List<int[]> ret = new ArrayList<>();
        while (i < m && j < n) {
            int[] f = firstList[i], s = secondList[j];
            if (f[0] <= s[1] && s[0] <= f[1]) {
                ret.add(new int[] { Math.max(f[0], s[0]), Math.min(f[1], s[1]) });
            }
            if (f[1] < s[1]) {
                ++i;
            } else {
                ++j;
            }
        }
        return ret.toArray(int[][]::new);
    }
}
// @lc code=end

