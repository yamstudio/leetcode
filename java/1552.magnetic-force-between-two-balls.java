/*
 * @lc app=leetcode id=1552 lang=java
 *
 * [1552] Magnetic Force Between Two Balls
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int maxDistance(int[] position, int m) {
        Arrays.sort(position);
        int n = position.length;
        int l = 0, r = position[n - 1] - position[0];
        while (l < r) {
            int mid = r - (r - l) / 2, p = position[0], count = 1;
            for (int i = 1; i < n && count < m; ++i) {
                if (position[i] - p >= mid) {
                    ++count;
                    p = position[i];
                }
            }
            if (count < m) {
                r = mid - 1;
            } else {
                l = mid;
            }
        }
        return l;
    }
}
// @lc code=end

