/*
 * @lc app=leetcode id=1643 lang=java
 *
 * [1643] Kth Smallest Instructions
 */

// @lc code=start
class Solution {
    public String kthSmallestPath(int[] destination, int k) {
        int v = destination[0], h = destination[1], n = h + v;
        int[][] comb = new int[n][n + 1];
        for (int i = 0; i < n; ++i) {
            comb[i][0] = 1;
            for (int j = 1; j <= i; ++j) {
                comb[i][j] = comb[i - 1][j] + comb[i - 1][j - 1];
            }
        }
        StringBuilder sb = new StringBuilder(n);
        for (int i = 0; i < n; ++i) {
            int chooseH = comb[n - 1 - i][v];
            if (chooseH < k) {
                k -= chooseH;
                v--;
                sb.append('V');
            } else {
                sb.append('H');
            }
        }
        return sb.toString();
    }
}
// @lc code=end

