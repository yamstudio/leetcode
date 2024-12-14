/*
 * @lc app=leetcode id=1014 lang=java
 *
 * [1014] Best Sightseeing Pair
 */

// @lc code=start
class Solution {
    public int maxScoreSightseeingPair(int[] values) {
        int n = values.length, m = values[n - 1] - 1, ret = Integer.MIN_VALUE;
        for (int i = n - 2; i >= 0; --i) {
            ret = Math.max(ret, values[i] + m);
            m = Math.max(m, values[i]) - 1;
        }
        return ret;
    }
}
// @lc code=end

