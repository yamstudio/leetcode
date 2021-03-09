/*
 * @lc app=leetcode id=909 lang=java
 *
 * [909] Snakes and Ladders
 */

// @lc code=start
class Solution {
    public int snakesAndLadders(int[][] board) {
        int n = board.length, d = n * n - 1, ret = 0;
        int[] pos = new int[d + 1];
        Set<Integer> visited = new HashSet<Integer>();
        Queue<Integer> queue = new LinkedList<Integer>();
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i % 2 == 0) {
                    pos[i * n + j] = board[n - 1 - i][j];
                } else {
                    pos[i * n + n - 1 - j] = board[n - 1 - i][j];
                }
            }
        }
        visited.add(0);
        queue.offer(0);
        while (queue.size() > 0) {
            for (int i = queue.size(); i > 0; --i) {
                int curr = queue.poll();
                if (curr == d) {
                    return ret;
                }
                for (int j = 1; j <= 6; ++j) {
                    int next = curr + j;
                    if (next > d) {
                        continue;
                    }
                    if (pos[next] > 0) {
                        next = pos[next] - 1;
                    }
                    if (visited.add(next)) {
                        queue.offer(next);
                    }
                }
            }
            ++ret;
        }
        return -1;
    }
}
// @lc code=end

