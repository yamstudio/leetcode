/*
 * @lc app=leetcode id=1536 lang=csharp
 *
 * [1536] Minimum Swaps to Arrange a Binary Grid
 */

// @lc code=start
public class Solution {
    public int MinSwaps(int[][] grid) {
        int n = grid.Length, ret = 0;
        int[] zeros = new int[n];
        for (int i = 0; i < n; ++i) {
            var row = grid[i];
            int j;
            for (j = n - 1; j >= 0 && row[j] == 0; --j);
            zeros[i] = n - j - 1;
        }
        for (int i = 0; i < n; ++i) {
            int need = n - i - 1, j = i;
            while (j < n && zeros[j] < need) {
                ++j;
            }
            if (j == n) {
                return -1;
            }
            ret += j - i;
            while (j > i) {
                var tmp = zeros[j];
                zeros[j] = zeros[j - 1];
                zeros[j - 1] = tmp;
                --j;
            }
        }
        return ret;
    }
}
// @lc code=end

