/*
 * @lc app=leetcode id=913 lang=java
 *
 * [913] Cat and Mouse
 */

// @lc code=start
class Solution {

    private static int catMouseGame(int[][] graph, int n, int k, int c, int m, int[][][] memo) {
        if (k == 2 * n) {
            return 3;
        }
        if (c == m) {
            return 2;
        }
        if (m == 0) {
            return 1;
        }
        if (memo[k][c][m] != 0) {
            return memo[k][c][m];
        }
        if (k % 2 == 0) {
            boolean catWin = true;
            for (int nm : graph[m]) {
                int b = catMouseGame(graph, n, k + 1, c, nm, memo);
                if (b == 1) {
                    return memo[k][c][m] = 1;
                }
                if (b == 3) {
                    catWin = false;
                }
            }
            if (catWin) {
                return memo[k][c][m] = 2;
            } else {
                return memo[k][c][m] = 3;
            }
        } else {
            boolean mouseWin = true;
            for (int nc : graph[c]) {
                if (nc == 0) {
                    continue;
                }
                int b = catMouseGame(graph, n, k + 1, nc, m, memo);
                if (b == 2) {
                    return memo[k][c][m] = 2;
                }
                if (b == 3) {
                    mouseWin = false;
                }
            }
            if (mouseWin) {
                return memo[k][c][m] = 1;
            } else {
                return memo[k][c][m] = 3;
            }
        }
    }

    public int catMouseGame(int[][] graph) {
        int n = graph.length;
        int ret = catMouseGame(graph, n, 0, 2, 1, new int[n * 2][n][n]);
        return ret == 3 ? 0 : ret;
    }
}
// @lc code=end

