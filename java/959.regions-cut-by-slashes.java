/*
 * @lc app=leetcode id=959 lang=java
 *
 * [959] Regions Cut By Slashes
 */

// @lc code=start
class Solution {
    public int regionsBySlashes(String[] grid) {
        int n = grid.length, m = 3 * n;
        boolean[][] blocks = new boolean[m][m];
        for (int i = 0; i < n; ++i) {
            String r = grid[i];
            for (int j = 0; j < n; ++j) {
                char c = r.charAt(j);
                if (c == '/') {
                    blocks[3 * i][3 * j + 2] = true;
                    blocks[3 * i + 1][3 * j + 1] = true;
                    blocks[3 * i + 2][3 * j] = true;
                } else if (c == '\\') {
                    blocks[3 * i][3 * j] = true;
                    blocks[3 * i + 1][3 * j + 1] = true;
                    blocks[3 * i + 2][3 * j + 2] = true;
                }
            }
        }
        int ret = 0;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < m; ++j) {
                if (!blocks[i][j]) {
                    ++ret;
                    visit(i, j, blocks);
                }
            }
        }
        return ret;
    }

    private static void visit(int i, int j, boolean[][] blocks) {
        int n = blocks.length;
        if (i < 0 || i >= n || j < 0 || j >= n || blocks[i][j]) {
            return;
        }
        blocks[i][j] = true;
        visit(i + 1, j, blocks);
        visit(i - 1, j, blocks);
        visit(i, j + 1, blocks);
        visit(i, j - 1, blocks);
    }
}
// @lc code=end

