/*
 * @lc app=leetcode id=913 lang=csharp
 *
 * [913] Cat and Mouse
 */

// @lc code=start
public class Solution {
    private const int UNDEFINED = 0, DRAW = 1, MOUSE = 2, CAT = 3;
    
    private static int CatMouseGameRecurse(int[][] graph, int[,,] dp, int n, int k, int x, int y) {
        if (k == 2 * n) {
            return DRAW;
        }
        if (x == y) {
            return dp[k, x, y] = CAT;
        }
        if (x == 0) {
            return dp[k, x, y] = MOUSE;
        }
        if (dp[k, x, y] != UNDEFINED) {
            return dp[k, x, y];
        }
        if (k % 2 == 0) {
            bool catWin = true;
            foreach (var nx in graph[x]) {
                int v = CatMouseGameRecurse(graph, dp, n, k + 1, nx, y);
                if (v == MOUSE) {
                    return dp[k, x, y] = MOUSE;
                } else if (v != CAT) {
                    catWin = false;
                }
            }
            if (catWin) {
                return dp[k, x, y] = CAT;
            } else {
                return dp[k, x, y] = DRAW;
            }
        } else {
            bool mouseWin = true;
            foreach (var ny in graph[y]) {
                if (ny == 0) {
                    continue;
                }
                int v = CatMouseGameRecurse(graph, dp, n, k + 1, x, ny);
                if (v == CAT) {
                    return dp[k, x, y] = CAT;
                } else if (v != MOUSE) {
                    mouseWin = false;
                }
            }
            if (mouseWin) {
                return dp[k, x, y] = MOUSE;
            } else {
                return dp[k, x, y] = DRAW;
            }
        }
    }

    public int CatMouseGame(int[][] graph) {
        int n = graph.Length;
        return CatMouseGameRecurse(graph, new int[2 * n, n, n], n, 0, 1, 2) - 1;
    }
}
// @lc code=end

