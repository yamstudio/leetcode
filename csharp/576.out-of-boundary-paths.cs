/*
 * @lc app=leetcode id=576 lang=csharp
 *
 * [576] Out of Boundary Paths
 */

// @lc code=start
public class Solution {
    public int FindPaths(int m, int n, int N, int i, int j) {
        long[,] prev = new long[m, n], curr = new long[m, n];
        while (N-- > 0) {
            for (int x = 0; x < m; ++x) {
                for (int y = 0; y < n; ++y) {
                    long up = x == 0 ? 1 : prev[x - 1, y];
                    long down = x == (m - 1) ? 1 : prev[x + 1, y];
                    long left = y == 0 ? 1 : prev[x, y - 1];
                    long right = y == (n - 1) ? 1 : prev[x, y + 1];
                    curr[x, y] = (up + down + left + right) % 1000000007;
                }
            }
            var tmp = curr;
            curr = prev;
            prev = tmp;
        }
        return (int) prev[i, j];
    }
}
// @lc code=end

