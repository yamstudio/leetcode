/*
 * @lc app=leetcode id=566 lang=csharp
 *
 * [566] Reshape the Matrix
 */

// @lc code=start
public class Solution {
    public int[][] MatrixReshape(int[][] nums, int r, int c) {
        int m = nums.Length, n, total;
        if (m == 0) {
            return nums;
        }
        n = nums[0].Length;
        total = r * c;
        if (m * n != total) {
            return nums;
        }
        int[][] ret = new int[r][];
        for (int i = 0; i < total; ++i) {
            int x = i / c, y = i % c;
            if (y == 0) {
                ret[x] = new int[c];
            }
            ret[x][y] = nums[i / n][i % n];
        }
        return ret;
    }
}
// @lc code=end

