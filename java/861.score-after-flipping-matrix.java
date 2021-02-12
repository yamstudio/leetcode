/*
 * @lc app=leetcode id=861 lang=java
 *
 * [861] Score After Flipping Matrix
 */

// @lc code=start
class Solution {
    public int matrixScore(int[][] A) {
        int m = A.length, n = A[0].length, ret = (1 << (n - 1)) * m;
        for (int j = 1; j < n; ++j) {
            int diff = 0;
            for (int i = 0; i < m; ++i) {
                diff += A[i][0] ^ A[i][j];
            }
            ret += (1 << (n - 1 - j)) * Math.max(diff, m - diff);
        }
        return ret;
    }
}
// @lc code=end

