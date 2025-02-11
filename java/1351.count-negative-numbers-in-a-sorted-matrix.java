/*
 * @lc app=leetcode id=1351 lang=java
 *
 * [1351] Count Negative Numbers in a Sorted Matrix
 */

// @lc code=start
class Solution {
    public int countNegatives(int[][] grid) {
        int n = grid[0].length, ret = 0;
        for (int i = grid.length - 1, l = 0; i >= 0 && l < n; --i) {
            int[] row = grid[i];
            int r = n;
            while (l < r) {
                int mid = (l + r) / 2;
                if (row[mid] >= 0) {
                    l = mid + 1;
                } else {
                    r = mid;
                }
            }
            ret += n - l;
        }
        return ret;
    }
}
// @lc code=end

