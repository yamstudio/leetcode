/*
 * @lc app=leetcode id=1284 lang=java
 *
 * [1284] Minimum Number of Flips to Convert Binary Matrix to Zero Matrix
 */

import java.util.ArrayDeque;
import java.util.HashSet;
import java.util.Queue;
import java.util.Set;

// @lc code=start
class Solution {
    public int minFlips(int[][] mat) {
        int start = 0, m = mat.length, n = mat[0].length, steps = 0;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                start |= (mat[i][j] << (i * n + j));
            }
        }
        Set<Integer> visited = new HashSet<>();
        Queue<Integer> queue = new ArrayDeque<>();
        visited.add(start);
        queue.offer(start);
        while (!queue.isEmpty()) {
            for (int k = queue.size(); k > 0; --k) {
                int curr = queue.poll();
                if (curr == 0) {
                    return steps;
                }
                for (int i = 0; i < m; ++i) {
                    for (int j = 0; j < n; ++j) {
                        int next = curr ^ (1 << (i * n + j));
                        if (i > 0) {
                            next = next ^ (1 << ((i - 1) * n + j));
                        }
                        if (i < m - 1) {
                            next = next ^ (1 << ((i + 1) * n + j));
                        }
                        if (j > 0) {
                            next = next ^ (1 << (i * n + j - 1));
                        }
                        if (j < n - 1) {
                            next = next ^ (1 << (i * n + j + 1));
                        }
                        if (visited.add(next)) {
                            queue.offer(next);
                        }
                    }
                }
            }
            ++steps;
        }
        return -1;
    }
}
// @lc code=end

