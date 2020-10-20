/*
 * @lc app=leetcode id=1351 lang=csharp
 *
 * [1351] Count Negative Numbers in a Sorted Matrix
 */

// @lc code=start
public class Solution {
    public int CountNegatives(int[][] grid) {
        int n = grid[0].Length, l = 0, ret = 0;
        for (int i = grid.Length - 1; i >= 0 && l < n; --i) {
            int[] row = grid[i];
            int r = n;
            while (l < r) {
                int c = (l + r) / 2;
                if (row[c] >= 0) {
                    l = c + 1;
                } else {
                    r = c;
                }
            }
            ret += n - l;
        }
        return ret;
    }
}
// @lc code=end

