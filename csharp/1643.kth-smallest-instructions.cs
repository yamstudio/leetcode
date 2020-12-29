/*
 * @lc app=leetcode id=1643 lang=csharp
 *
 * [1643] Kth Smallest Instructions
 */

// @lc code=start
public class Solution {
    public string KthSmallestPath(int[] destination, int k) {
        int h = destination[1], v = destination[0], n = h + v;
        int[,] choose = new int[n + 1, n + 1];
        char[] ret = new char[n];
        for (int i = 0; i <= n; ++i) {
            choose[i, 0] = 1;
            for (int j = 1; j <= i; ++j) {
                choose[i, j] = choose[i - 1, j] + choose[i - 1, j - 1];
            }
        }
        for (int i = 0; i < n; ++i) {
            int c = choose[n - i - 1, v];
            if (c >= k) {
                ret[i] = 'H';
            } else {
                --v;
                k -= c;
                ret[i] = 'V';
            }
        }
        return new string(ret);
    }
}
// @lc code=end

