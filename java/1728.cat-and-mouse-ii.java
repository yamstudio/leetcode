/*
 * @lc app=leetcode id=1728 lang=java
 *
 * [1728] Cat and Mouse II
 */

// @lc code=start
class Solution {
    
    private static final int[][] DIRS = new int[][] {
        new int[] { -1, 0, },
        new int[] { 1, 0, },
        new int[] { 0, -1, },
        new int[] { 0, 1, },
    };
    
    public boolean canMouseWin(String[] grid, int catJump, int mouseJump) {
        int m = grid.length, n = grid[0].length(), cr = -1, cc = -1, mr = -1, mc = -1, free = 0;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                char c = grid[i].charAt(j);
                if (c == 'M') {
                    mr = i;
                    mc = j;
                    ++free;
                } else if (c == 'C') {
                    cr = i;
                    cc = j;
                    ++free;
                } else if (c != '#') {
                    ++free;
                }
            }
        }
        return canMouseWin(grid, catJump, mouseJump, mr, mc, cr, cc, 2 * free, 0, new Boolean[m][n][m][n][2 * free]);
    }

    private static boolean canMouseWin(String[] grid, int catJump, int mouseJump, int mr, int mc, int cr, int cc, int max, int steps, Boolean[][][][][] memo) {
        if (steps >= max) {
            return false;
        }
        Boolean r = memo[mr][mc][cr][cc][steps];
        if (r != null) {
            return r;
        }
        int m = grid.length, n = grid[0].length();
        if (steps % 2 == 0) {
            for (int[] dir : DIRS) {
                int dr = dir[0], dc = dir[1];
                for (int mul = 0; mul <= mouseJump; ++mul) {
                    int nr = mr + dr * mul, nc = mc + dc * mul;
                    if (nr < 0 || nr >= m || nc < 0 || nc >= n || grid[nr].charAt(nc) == '#') {
                        break;
                    }
                    if (grid[nr].charAt(nc) == 'F' || canMouseWin(grid, catJump, mouseJump, nr, nc, cr, cc, max, steps + 1, memo)) {
                        memo[mr][mc][cr][cc][steps] = true;
                        return true;
                    }
                }
            }
            memo[mr][mc][cr][cc][steps] = false;
            return false;
        } else {
            for (int[] dir : DIRS) {
                int dr = dir[0], dc = dir[1];
                for (int mul = 0; mul <= catJump; ++mul) {
                    int nr = cr + dr * mul, nc = cc + dc * mul;
                    if (nr < 0 || nr >= m || nc < 0 || nc >= n || grid[nr].charAt(nc) == '#') {
                        break;
                    }
                    if (grid[nr].charAt(nc) == 'F' || (nr == mr && nc == mc) || !canMouseWin(grid, catJump, mouseJump, mr, mc, nr, nc, max, steps + 1, memo)) {
                        memo[mr][mc][cr][cc][steps] = false;
                        return false;
                    }
                }
            }
            memo[mr][mc][cr][cc][steps] = true;
            return true;
        }
    }
}
// @lc code=end

