/*
 * @lc app=leetcode id=1552 lang=csharp
 *
 * [1552] Magnetic Force Between Two Balls
 */

using System;

// @lc code=start
public class Solution {
    public int MaxDistance(int[] position, int m) {
        int n = position.Length;
        Array.Sort(position);
        int l = 0, r = position[n - 1] - position[0];
        while (l < r) {
            int mid = r - (r - l) / 2, p = position[0], count = 1;
            for (int j = 1; j < n && count < m; ++j) {
                if (position[j] - p >= mid) {
                    p = position[j];
                    ++count;
                }
            }
            if (count >= m) {
                l = mid;
            } else {
                r = mid - 1;
            }
        }
        return l;
    }
}
// @lc code=end

