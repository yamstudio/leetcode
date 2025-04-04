/*
 * @lc app=leetcode id=1536 lang=java
 *
 * [1536] Minimum Swaps to Arrange a Binary Grid
 */

// @lc code=start
class Solution {
    public int minSwaps(int[][] grid) {
        int n = grid.length, ret = 0;
        int[] count = new int[n];
        for (int i = 0; i < n; ++i) {
            int j;
            for (j = n - 1; j >= 0 && grid[i][j] == 0; --j);
            count[i] = n - 1 - j;
        }
        for (int i = 0; i < n; ++i) {
            int want = n - 1 - i;
            int j;
            for (j = i; j < n && count[j] < want; ++j);
            if (j == n) {
                return -1;
            }
            ret += j - i;
            int tmp = count[j];
            for (; j > i; --j) {
                count[j] = count[j - 1];
            }
            count[i] = tmp;
        }
        return ret;
    }
}
// @lc code=end

