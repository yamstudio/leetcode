/*
 * @lc app=leetcode id=959 lang=csharp
 *
 * [959] Regions Cut By Slashes
 */

// @lc code=start
public class Solution {

    private static void Visit(bool[,] map, int n, int i, int j) {
        if (i < 0 || i == n || j < 0 || j == n || map[i, j]) {
            return;
        }
        map[i, j] = true;
        Visit(map, n, i - 1, j);
        Visit(map, n, i + 1, j);
        Visit(map, n, i, j - 1);
        Visit(map, n, i, j + 1);
    }

    public int RegionsBySlashes(string[] grid) {
        int n = grid.Length, ret = 0;
        var map = new bool[n * 3, n * 3];
        for (int i = 0; i < n; ++i) {
            string row = grid[i];
            for (int j = 0; j < n; ++j) {
                char c = row[j];
                int mi = 3 * i, mj = 3 * j;
                if (c == '/') {
                    map[mi, mj + 2] = true;
                    map[mi + 1, mj + 1] = true;
                    map[mi + 2, mj] = true;
                } else if (c == '\\') {
                    map[mi, mj] = true;
                    map[mi + 1, mj + 1] = true;
                    map[mi + 2, mj + 2] = true;
                }
            }
        }
        n *= 3;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (!map[i, j]) {
                    ++ret;
                    Visit(map, n, i, j);
                }
            }
        }
        return ret;
    }
}
// @lc code=end

