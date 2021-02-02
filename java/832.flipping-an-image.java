/*
 * @lc app=leetcode id=832 lang=java
 *
 * [832] Flipping an Image
 */

// @lc code=start
class Solution {
    public int[][] flipAndInvertImage(int[][] A) {
        int n = A[0].length;
        for (int[] row : A) {
            for (int i = 0; i * 2 < n; ++i) {
                if (row[i] == row[n - 1 - i]) {
                    int v = 1 - row[i];
                    row[i] = v;
                    row[n - 1 - i] = v;
                }
            }
        }
        return A;
    }
}
// @lc code=end

