/*
 * @lc app=leetcode id=1725 lang=java
 *
 * [1725] Number Of Rectangles That Can Form The Largest Square
 */

// @lc code=start
class Solution {
    public int countGoodRectangles(int[][] rectangles) {
        int m = 0, ret = 0;
        for (int[] r : rectangles) {
            int l = Math.min(r[0], r[1]);
            if (l > m) {
                m = l;
                ret = 1;
            } else if (l == m) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

