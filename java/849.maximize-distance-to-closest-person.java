/*
 * @lc app=leetcode id=849 lang=java
 *
 * [849] Maximize Distance to Closest Person
 */

// @lc code=start
class Solution {
    public int maxDistToClosest(int[] seats) {
        int n = seats.length, ret = 0, p = -1;
        for (int i = 0; i < n; ++i) {
            if (seats[i] == 0) {
                continue;
            }
            if (p == -1) {
                ret = i;
            } else {
                ret = Math.max(ret, (i - p) / 2);
            }
            p = i;
        }
        ret = Math.max(ret, n - p - 1);
        return ret;
    }
}
// @lc code=end

