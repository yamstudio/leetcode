/*
 * @lc app=leetcode id=827 lang=java
 *
 * [827] Making A Large Island
 */

// @lc code=start
class Solution {

    private static int color(int[][] grid, int i, int j, int color) {
        int m = grid.length, n = grid[0].length;
        if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] != 1) {
            return 0;
        }
        grid[i][j] = color;
        return 1 + color(grid, i - 1, j, color) + color(grid, i + 1, j, color) + color(grid, i, j - 1, color) + color(grid, i, j + 1, color);
    }

    private static void tryAdd(int[][] grid, int i, int j, Set<Integer> set) {
        int m = grid.length, n = grid[0].length;
        if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] == 0) {
            return;
        }
        set.add(grid[i][j]);
    }

    public int largestIsland(int[][] grid) {
        int m = grid.length, n = grid[0].length, ret = 0;
        List<Integer> sizes = new ArrayList<Integer>();
        sizes.add(0);
        sizes.add(0);
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 1) {
                    int t = color(grid, i, j, sizes.size());
                    ret = Math.max(ret, t);
                    sizes.add(t);
                }
            }
        }
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] != 0) {
                    continue;
                }
                int s = 1;
                Set<Integer> islands = new HashSet<Integer>(4);
                tryAdd(grid, i - 1, j, islands);
                tryAdd(grid, i + 1, j, islands);
                tryAdd(grid, i, j - 1, islands);
                tryAdd(grid, i, j + 1, islands);
                for (int island : islands) {
                    s += sizes.get(island);
                }
                ret = Math.max(s, ret);
            }
        }
        return ret;
    }
}
// @lc code=end

