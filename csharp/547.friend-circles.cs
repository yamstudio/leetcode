/*
 * @lc app=leetcode id=547 lang=csharp
 *
 * [547] Friend Circles
 */

// @lc code=start
public class Solution {

    private static void FindCircleNumRecurse(int[][] M, int n, int i, bool[] visited) {
        visited[i] = true;
        for (int j = 0; j < n; ++j) {
            if (M[i][j] == 1 && !visited[j]) {
                FindCircleNumRecurse(M, n, j, visited);
            }
        }
    }

    public int FindCircleNum(int[][] M) {
        int n = M.Length, ret = 0;
        bool[] visited = new bool[n];
        for (int i = 0; i < n; ++i) {
            if (!visited[i]) {
                FindCircleNumRecurse(M, n, i, visited);
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

