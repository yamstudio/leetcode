/*
 * @lc app=leetcode id=1582 lang=java
 *
 * [1582] Special Positions in a Binary Matrix
 */

// @lc code=start
class Solution {
    public int numSpecial(int[][] mat) {
        int m = mat.length, n = mat[0].length, ret = 0;
        int[] colCount = new int[n];
        for (int i = 0; i < m; ++i) {
            int oneIndex = -1;
            for (int j = 0; j < n; ++j) {
                if (mat[i][j] == 0) {
                    continue;
                }
                if (oneIndex == -1) {
                    oneIndex = j;
                } else {
                    oneIndex = -1;
                    break;
                }
            }
            if (oneIndex == -1 || colCount[oneIndex] != 0) {
                continue;
            }
            for (int mi = 0; mi < m; ++mi) {
                colCount[oneIndex] += mat[mi][oneIndex];
            }
            if (colCount[oneIndex] == 1) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

