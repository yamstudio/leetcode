/*
 * @lc app=leetcode id=864 lang=java
 *
 * [864] Shortest Path to Get All Keys
 */

// @lc code=start
class Solution {

    private static int[][] directions = new int[][] {
        new int[] { -1, 0 },
        new int[] { 1, 0 },
        new int[] { 0, -1 },
        new int[] { 0, 1 }
    };

    public int shortestPathAllKeys(String[] grid) {
        int m = grid.length, n = grid[0].length(), k = 0, ret = 0;
        Set<String> visited = new HashSet<String>();
        Queue<int[]> queue = new LinkedList<int[]>();
        for (int i = 0; i < m; ++i) {
            String row = grid[i];
            for (int j = 0; j < n; ++j) {
                char c = row.charAt(j);
                if (c >= 'a' && c <= 'f') {
                    ++k;
                } else if (c == '@') {
                    visited.add(String.format("%d,%d,%d", i, j, 0));
                    queue.offer(new int[] { i, j, 0 });
                }
            }
        }
        k = (1 << k) - 1;
        while (queue.size() > 0) {
            for (int t = queue.size(); t > 0; --t) {
                int[] curr = queue.poll();
                int i = curr[0], j = curr[1], state = curr[2];
                char c = grid[i].charAt(j);
                if (c >= 'a' && c <= 'f') {
                    state = state | (1 << ((int)c - (int)'a'));
                }
                if (state == k) {
                    return ret;
                }
                for (int[] dir : directions) {
                    int ni = i + dir[0], nj = j + dir[1];
                    if (ni < 0 || ni >= m || nj < 0 || nj >= n) {
                        continue;
                    }
                    char nc = grid[ni].charAt(nj);
                    if (nc == '#' || nc >= 'A' && nc <= 'F' && (state & (1 << ((int)nc - (int)'A'))) == 0) {
                        continue;
                    }
                    String key = String.format("%d,%d,%d", ni, nj, state);
                    if (visited.add(key)) {
                        queue.offer(new int[] { ni, nj, state });
                    }
                }
            }
            ++ret;
        }
        return -1;
    }
}
// @lc code=end

