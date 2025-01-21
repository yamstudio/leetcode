/*
 * @lc app=leetcode id=1267 lang=java
 *
 * [1267] Count Servers that Communicate
 */

import java.util.HashSet;
import java.util.Set;

// @lc code=start

class Solution {
    public int countServers(int[][] grid) {
        int m = grid.length, n = grid[0].length, ret = 0;
        Set<Integer> cols = new HashSet<>();
        for (int i = 0; i < m; ++i) {
            boolean scannedRow = false;
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 0) {
                    continue;
                }
                boolean canCommunicate = false;
                if (!scannedRow) {
                    for (int nj = j + 1; nj < n; ++nj) {
                        if (grid[i][nj] == 1) {
                            canCommunicate = true;
                            if (!cols.contains(nj)) {
                                ++ret;
                            }
                        }
                    }
                }
                if (!cols.contains(j)) {
                    for (int ni = i + 1; ni < m; ++ni) {
                        if (grid[ni][j] == 1) {
                            canCommunicate = true;
                            ++ret;
                        }
                    }
                }
                if (canCommunicate && !scannedRow && !cols.contains(j)) {
                    ++ret;
                }
                scannedRow = true;
                cols.add(j);
            }
        }
        return ret;
    }
}
// @lc code=end

