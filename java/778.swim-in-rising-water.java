/*
 * @lc app=leetcode id=778 lang=java
 *
 * [778] Swim in Rising Water
 */

// @lc code=start
class Solution {

    private static int[][] dirs = new int[][] {
        new int[] { -1, 0 },
        new int[] { 1, 0 },
        new int[] { 0, -1 },
        new int[] { 0, 1}
    };

    public int swimInWater(int[][] grid) {
        PriorityQueue<int[]> pq = new PriorityQueue<int[]>((a, b) -> Integer.compare(a[0], b[0]));
        int n = grid.length, ret = Math.max(grid[0][0], grid[n - 1][n - 1]);
        boolean[][] visited = new boolean[n][];
        for (int i = 0; i < n; ++i) {
            visited[i] = new boolean[n];
        }
        pq.offer(new int[] { grid[0][0], 0, 0 });
        visited[0][0] = true;
        while (pq.size() > 0) {
            int[] curr = pq.poll();
            ret = Math.max(ret, curr[0]);
            for (int[] dir : dirs) {
                int nr = dir[0] + curr[1], nc = dir[1] + curr[2];
                if (nr < 0 || nr >= n || nc < 0 || nc >= n || visited[nr][nc]) {
                    continue;
                }
                if (nr == n - 1 && nc == n - 1) {
                    return ret;
                }
                visited[nr][nc] = true;
                pq.offer(new int[] { grid[nr][nc], nr, nc });
            }
        }
        return -1;
    }
}
// @lc code=end

