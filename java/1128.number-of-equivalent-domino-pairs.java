/*
 * @lc app=leetcode id=1128 lang=java
 *
 * [1128] Number of Equivalent Domino Pairs
 */

// @lc code=start
class Solution {
    public int numEquivDominoPairs(int[][] dominoes) {
        int[] count = new int[81];
        for (int[] d : dominoes) {
            count[(Math.min(d[0], d[1]) - 1) + 9 * (Math.max(d[0], d[1]) - 1)]++;
        }
        int ret = 0;
        for (int c : count) {
            ret += c * (c - 1) / 2;
        }
        return ret;
    }
}
// @lc code=end

