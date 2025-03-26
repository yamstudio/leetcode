/*
 * @lc app=leetcode id=1503 lang=java
 *
 * [1503] Last Moment Before All Ants Fall Out of a Plank
 */

// @lc code=start
class Solution {
    public int getLastMoment(int n, int[] left, int[] right) {
        int ret = 0;
        for (int x : left) {
            ret = Math.max(ret, x);
        }
        for (int x : right) {
            ret = Math.max(ret, n - x);
        }
        return ret;
    }
}
// @lc code=end

